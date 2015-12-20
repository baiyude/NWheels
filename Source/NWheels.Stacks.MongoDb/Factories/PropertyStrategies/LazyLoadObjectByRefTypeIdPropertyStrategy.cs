﻿using System;
using Autofac;
using Hapil;
using Hapil.Operands;
using Hapil.Writers;
using NWheels.DataObjects;
using NWheels.DataObjects.Core.Factories;
using NWheels.Entities;
using NWheels.Entities.Core;
using NWheels.Entities.Factories;
using TT = Hapil.TypeTemplate;
using TT2 = NWheels.Stacks.MongoDb.Factories.PropertyStrategies.PersistableTypeTemplates;
using NWheels.Stacks.MongoDb.LazyLoaders;

namespace NWheels.Stacks.MongoDb.Factories.PropertyStrategies
{
    public class LazyLoadObjectByRefTypeIdPropertyStrategy : PropertyImplementationStrategy
    {
        private Type _idType;
        private Field<TT.TKey> _backingField;
        private Type _relatedContractType;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public LazyLoadObjectByRefTypeIdPropertyStrategy(
            PropertyImplementationStrategyMap ownerMap,
            ObjectFactoryContext factoryContext,
            ITypeMetadataCache metadataCache,
            ITypeMetadata metaType,
            IPropertyMetadata metaProperty)
            : base(ownerMap, factoryContext, metadataCache, metaType, metaProperty)
        {
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        #region Overrides of PropertyImplementationStrategy

        protected override void OnBeforeImplementation(ImplementationClassWriter<TypeTemplate.TInterface> writer)
        {
            _relatedContractType = MetaProperty.Relation.RelatedPartyType.ContractType;
            _idType = MetaProperty.Relation.RelatedPartyType.EntityIdProperty.ClrType;

            using ( TT.CreateScope<TT.TKey>(_idType) )
            {
                _backingField = writer.Field<TT.TKey>("m_" + MetaProperty.Name);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override void OnImplementContractProperty(ImplementationClassWriter<TypeTemplate.TInterface> writer)
        {
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override void OnImplementStorageProperty(ImplementationClassWriter<TypeTemplate.TInterface> writer)
        {
            using ( TT.CreateScope<TT.TKey>(_idType) )
            {
                writer.NewVirtualWritableProperty<TT.TKey>(MetaProperty.Name).ImplementAutomatic(_backingField);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override void OnWritingImportStorageValue(MethodWriterBase writer, Operand<IEntityRepository> entityRepo, Operand<object[]> valueVector)
        {
            using ( TT.CreateScope<TT.TKey>(_idType) )
            {
                _backingField.Assign(
                    Static.GenericFunc(v => PersistableObjectRuntimeHelpers.ImportPersistableLazyLoadObject<TT.TKey>(v),
                        valueVector.ItemAt(MetaProperty.PropertyIndex)
                    )
                );
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override void OnWritingExportStorageValue(MethodWriterBase writer, Operand<IEntityRepository> entityRepo, Operand<object[]> valueVector)
        {
            using ( TT.CreateScope<TT.TKey>(_idType) )
            {
                writer.If(_backingField.IsNotNull()).Then(() => {
                    valueVector.ItemAt(MetaProperty.PropertyIndex).Assign(
                        writer.New<ObjectLazyLoaderById>(
                            entityRepo.Prop(x => x.OwnerContext).Func<Type, IEntityRepository>(x => x.GetEntityRepository, writer.Const(_relatedContractType)),
                            _backingField.CastTo<object>()
                        )
                    );
                }).Else(() => {
                    valueVector.ItemAt(MetaProperty.PropertyIndex).Assign(writer.Const<object>(null));
                });
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override void OnWritingInitializationConstructor(MethodWriterBase writer, Operand<IComponentContext> components, params IOperand[] args)
        {
        }

        #endregion
    }
}
