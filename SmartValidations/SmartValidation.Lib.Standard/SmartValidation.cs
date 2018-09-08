using System;
using System.Linq;

namespace SmartValidation.Lib.Standard
{
    public static class SmartValidation
    {
        public static void ValidateMail(String mail)
        {

        }

        public static Boolean ValidateCPF(String cpf)
        {
            if (cpf.Length < 11 || cpf.Length > 11)
                return false;

            if (cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444"
                || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888"
                || cpf == "99999999999" || cpf == "00000000000")
                return false;

            int sumChars = 0;

            for (int i = 0, j = 11; i < cpf.Length-1; i++, j--)
                sumChars += Convert.ToInt32(cpf[i].ToString()) * j;

            sumChars = (sumChars * 10) % 11;

            return sumChars.ToString() == cpf[10].ToString() ? true : false;
        }

        public static Boolean ValidateCNPJ(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            if (cnpj.Any(n => n < '0' || n > '9'))
                return false;

            var cnpjNums = cnpj.Select(c => Convert.ToInt32(c.ToString()));

            int[] firstMultipliers = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = firstMultipliers.Zip(cnpjNums, (m, c) => m * c).Sum();

            int firstVerifyingDigit = (sum % 11) < 2 ? 0 : 11 - sum % 11;
            if (cnpj[12].ToString() != firstVerifyingDigit.ToString())
                return false;

            int[] secondMultipliers = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = secondMultipliers.Zip(cnpjNums, (m, c) => m * c).Sum();

            int secondVerifyingDigit = (sum % 11) < 2 ? 0 : 11 - sum % 11;
            if (cnpj[13].ToString() != secondVerifyingDigit.ToString())
                return false;

            return true;
        }
    }
}
