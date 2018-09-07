using System;

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
    }
}
