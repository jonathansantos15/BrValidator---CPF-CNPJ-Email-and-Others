using System;
using System.Linq;

namespace SmartValidation.Lib.Standard
{
    public static class SmartValidation
    {
        public static Boolean ValidateMail(String mail)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(mail, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
        }

        public static Boolean ValidateCPF(String cpf)
        {
            if (cpf.Length < 11 || cpf.Length > 11)
                return false;

            if (cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" ||
                cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" ||
                cpf == "99999999999" || cpf == "00000000000")
                return false;

            int sumChars = 0;

            for (int i = 0, j = 11; i < cpf.Length - 1; i++, j--)
                sumChars += Convert.ToInt32(cpf[i].ToString()) * j;

            sumChars = (sumChars * 10) % 11;

            return sumChars.ToString() == cpf[10].ToString() ? true : false;
        }

        public static Boolean ValidateCNPJ(String cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            if (!IsNumber(cnpj))
                return false;

            if (cnpj == "11111111111" || cnpj == "22222222222" || cnpj == "33333333333" || cnpj == "44444444444" ||
                cnpj == "55555555555" || cnpj == "66666666666" || cnpj == "77777777777" || cnpj == "88888888888" ||
                cnpj == "99999999999" || cnpj == "00000000000")
                return false;

            String cnpjNums = String.Empty;

            Int32[] firstMultipliers = new Int32[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            Int32 sum = 0;

            for (Int32 i = 0; i < cnpj.Length-2; i++)
                sum += Convert.ToInt32(firstMultipliers[i] * Convert.ToUInt32(cnpj[i].ToString()));

            Int32 firstVerifyingDigit = (sum % 11) < 2 ? 0 : 11 - sum % 11;
            if (cnpj[12].ToString() != firstVerifyingDigit.ToString())
                return false;

            Int32[] secondMultipliers = new Int32[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            sum = 0;

            for (Int32 i = 0; i < cnpj.Length - 1; i++)
                sum += Convert.ToInt32(secondMultipliers[i] * Convert.ToUInt32(cnpj[i].ToString()));

            Int32 secondVerifyingDigit = (sum % 11) < 2 ? 0 : 11 - sum % 11;
            if (cnpj[13].ToString() != secondVerifyingDigit.ToString())
                return false;

            return true;
        }

        private static Boolean IsNumber(String s)
        {
            for (Int32 i = 0; i < s.Length - 1; i++)
            {
                if (!Char.IsDigit(s[i]))
                    return false;
            }

            return true;
        }
    }
}
