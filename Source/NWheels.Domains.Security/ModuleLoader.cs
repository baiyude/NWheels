﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NWheels.Authorization.Impl;
using NWheels.Domains.Security.Core;
using NWheels.Domains.Security.Impl;
using NWheels.Domains.Security.UI;
using NWheels.Extensions;
using NWheels.UI.Core;

namespace NWheels.Domains.Security
{
    public class ModuleLoader : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.NWheelsFeatures().Logging().RegisterLogger<ISecurityDomainLogger>();
            builder.NWheelsFeatures().Entities().RegisterDataRepository<IUserAccountDataRepository>();

            builder.RegisterType<DefaultCryptoProvider>().As<ICryptoProvider>().SingleInstance();
            builder.RegisterType<PrivateAuthenticationProvider>().As<IAuthenticationProvider>().SingleInstance();
            builder.RegisterType<ClaimFactory>().SingleInstance();

            builder.NWheelsFeatures().Processing().RegisterTransactionScript<UserLoginTransactionScript>().InstancePerDependency();
            builder.NWheelsFeatures().Processing().RegisterTransactionScript<UserLogoutTransactionScript>().InstancePerDependency();
            builder.NWheelsFeatures().Processing().RegisterTransactionScript<ChangePasswordTransactionScript>().InstancePerDependency();

            builder.RegisterType<JsonSerializationExtension>().As<IJsonSerializationExtension>();
            builder.RegisterType<UserAccountPolicySet>();

            builder.NWheelsFeatures().ObjectContracts().Concretize<IUserAccountEntity>().With<UserAccountEntity>();
            builder.NWheelsFeatures().ObjectContracts().Concretize<IAllowAllEntityAccessRuleEntity>().With<AllowAllEntityAccessRuleEntity>();
            builder.NWheelsFeatures().ObjectContracts().Concretize<IProfilePhotoEntity>().With<ProfilePhotoEntity>();
        }
    }
}
