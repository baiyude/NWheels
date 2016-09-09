﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWheels.Authorization.Core;
using NWheels.Domains.DevOps.SystemLogs.Entities;
using NWheels.Domains.DevOps.SystemLogs.UI.Screens;
using NWheels.Domains.Security;
using NWheels.Domains.Security.Core;
using NWheels.Extensions;
using NWheels.Globalization;
using NWheels.Samples.MyHRApp.Domain;
using NWheels.UI;
using NWheels.UI.Factories;
using NWheels.UI.Uidl;

namespace NWheels.Samples.MyHRApp.UI
{
    [RequireDomainContext(typeof(IHRContext))]
    [RequireDomainContext(typeof(ISystemLogContext))]
    public class HRApp : ApplicationBase<HRApp, Empty.Input, Empty.Data, HRApp.IState>
    {

        protected override void DescribePresenter(PresenterBuilder<HRApp, Empty.Data, HRApp.IState> presenter)
        {
            DefaultSkin = "inspinia";

            presenter.On(RequestNotAuthorized)
                .Navigate().ToScreen(Login)
                .Then(b => b.UserAlertFrom<IAlerts>().ShowInline((x, vm) => x.LogInToAuthorizeRequestedOperation()));

            presenter.On(UserAlreadyAuthenticated)
                .ActivateSessionTimeout();

            base.SetInitialScreen(ifNotAuthenticated: Login, ifAuthenticated: MainScreen);

            presenter.On(Login.LoginForm.OutputReady)
                .AlterModel(
                    alt => alt.Copy(true).To(m => m.State.IsRegisteredUser),
                    alt => alt.Copy(vm => vm.Input).To(vm => vm.State.LoggedInUser))
                .Then(b => b.Navigate().ToScreen(MainScreen));

            presenter.On(MainScreen.CurrentUser.UserLoggedOut)
                .DeactivateSessionTimeout()
                .Then(b => b.Navigate().ToScreen(Login));

            presenter.On(UserSessionExpired)
                .UserAlertFrom<IAlerts>().ShowModal((alerts, vm) => alerts.YourSessionHasExpiredPleaseLogInToContinue())
                .Then(b => b.Navigate().ToScreen(Login));

            presenter.On(ServerConnectionLost)
                .UserAlertFrom<IAlerts>().ShowModal((alerts, vm) => alerts.ConnectionToServerHasBeenLost())
                .Then(b => b.RestartApp());
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        public HRLoginScreen Login { get; set; }
        public HRMainScreen MainScreen { get; set; }
        public SystemLogScreen SystemLog { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        #region Overrides of ApplicationBase<AdminApp,Input,Data,IState>

        protected override IState OnCreateViewStateForCurrentUser(IViewModelObjectFactory viewModelFactory)
        {
            var currentSession = Session.Current;
            var state = viewModelFactory.NewEntity<IState>();

            if (currentSession.UserIdentity.IsAuthenticated)
            {
                state.IsRegisteredUser = true;
                state.LoggedInUser = new UserLoginTransactionScript.Result(
                    currentSession.UserPrincipal.As<UserAccountPrincipal>(),
                    currentSession.Endpoint,
                    MetadataCache);
            }

            return state;
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        [ViewModelContract]
        public interface IState
        {
            UserLoginTransactionScript.Result LoggedInUser { get; set; }

            [ViewModelPropertyContract.PersistedOnUserMachine]
            bool IsRegisteredUser { get; set; }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        [DefaultCulture("en-US")]
        public interface IAlerts : IUserAlertRepository
        {
            [WarningAlert]
            UidlUserAlert LogInToAuthorizeRequestedOperation();

            [InfoAlert]
            UidlUserAlert FeatureIsNotYetImplemented();

            [WarningAlert(UserAlertResult.OK)]
            UidlUserAlert YourSessionHasExpiredPleaseLogInToContinue();

            [ErrorAlert(UserAlertResult.OK)]
            UidlUserAlert ConnectionToServerHasBeenLost();
        }
    }
}