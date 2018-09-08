using FluentAssertions;
using System;
using Xunit;

namespace SmartValidation.Lib.Core.Tests
{
    public class SmartValidationTests
    {
        [Theory]
        [InlineData("20558041892")]
        [InlineData("74630207201")]
        [InlineData("63564107282")]
        [InlineData("72499567287")]
        [InlineData("53828337295")]
        [InlineData("24356766113")]
        public void TestCpfMustBeValid(string cpf)
        {
            Boolean cpfIsValid = Standard.SmartValidation.ValidateCPF(cpf);

            cpfIsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("20558341892")]
        [InlineData("74630207101")]
        [InlineData("63564107582")]
        [InlineData("72489567287")]
        [InlineData("53828137295")]
        [InlineData("24356726113")]
        public void TestCpfMustBeInvalid(string cpf)
        {
            Boolean cpfIsValid = Standard.SmartValidation.ValidateCPF(cpf);

            cpfIsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        [InlineData("00000000000")]
        public void TestCpfWithEqualNumbersMustBeInvalid(string cpf)
        {
            Boolean cpfIsValid = Standard.SmartValidation.ValidateCPF(cpf);

            cpfIsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("30409232000169")]
        [InlineData("09347313000195")]
        public void TestCnpjMustBeValid(string cnpj)
        {
            Boolean cnpjIsValid = Standard.SmartValidation.ValidateCNPJ(cnpj);

            cnpjIsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("30409232100169")]
        [InlineData("09347313000191")]
        public void TestCnpjMustBeInvalid(string cnpj)
        {
            Boolean cnpjIsValid = Standard.SmartValidation.ValidateCNPJ(cnpj);

            cnpjIsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("304092321001XX")]
        [InlineData("O9347313000191")]
        public void TestCnpjWithLettersMustBeInvalid(string cnpj)
        {
            Boolean cnpjIsValid = Standard.SmartValidation.ValidateCNPJ(cnpj);

            cnpjIsValid.Should().BeFalse();
        }
    }
}
