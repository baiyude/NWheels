﻿using FluentAssertions;
using NWheels.Compilation.Mechanism.Syntax;
using NWheels.Compilation.Mechanism.Syntax.Expressions;
using NWheels.Compilation.Mechanism.Syntax.Members;
using NWheels.Compilation.Mechanism.Syntax.Statements;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NWheels.Implementation.UnitTests.Compilation.Mechanism.Syntax
{
    public class TypeReferenceStatementVisitorTests
    {
        [Fact]
        public void VisitBlockStatement_LocalVariableTypesIncluded()
        {
            //-- arrange

            var block = new BlockStatement(
                new VariableDeclarationStatement { Variable = new LocalVariable { Name = "x", Type = typeof(IDisposable) } }
            );

            var foundTypes = new HashSet<TypeMember>();
            var visitor = new TypeReferenceStatementVisitor(foundTypes);

            //-- act

            block.AcceptVisitor(visitor);

            //-- assert

            foundTypes.Should().BeEquivalentTo(new TypeMember[] { typeof(IDisposable) });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void VisitBlockStatement_TypeofConstantsIncluded()
        {
            //-- arrange

            var block = new BlockStatement(
                new ReturnStatement { Expression = new ConstantExpression { Value = typeof(IDisposable) } },
                new ReturnStatement { Expression = new ConstantExpression { Value = (TypeMember)typeof(IFormattable) } }
            );

            var foundTypes = new HashSet<TypeMember>();
            var visitor = new TypeReferenceStatementVisitor(foundTypes);

            //-- act

            block.AcceptVisitor(visitor);

            //-- assert

            foundTypes.Should().BeEquivalentTo(new TypeMember[] { typeof(IDisposable), typeof(IFormattable) });
        }
    }
}
