using System;

namespace BrValidator.Lib.Standard
{
    public static class BrValidator
    {
        public static Boolean ValidateMail(String mail)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(mail, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
        }

        public static Boolean ValidateCPF(String CPF)
        {
            if (CPF.Length < 11 || CPF.Length > 11)
                return false;

            if (CPF == "11111111111" || CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" ||
                CPF == "55555555555" || CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888" ||
                CPF == "99999999999" || CPF == "00000000000")
                return false;

            int sumChars = 0;

            for (int i = 0, j = 11; i < CPF.Length - 1; i++, j--)
                sumChars += Convert.ToInt32(CPF[i].ToString()) * j;

            sumChars = (sumChars * 10) % 11;

            return sumChars.ToString() == CPF[10].ToString() ? true : false;
        }

        public static Boolean ValidateCNPJ(String CNPJ)
        {
            if (CNPJ.Length != 14)
                return false;

            if (!IsNumber(CNPJ))
                return false;

            if (CNPJ == "11111111111" || CNPJ == "22222222222" || CNPJ == "33333333333" || CNPJ == "44444444444" ||
                CNPJ == "55555555555" || CNPJ == "66666666666" || CNPJ == "77777777777" || CNPJ == "88888888888" ||
                CNPJ == "99999999999" || CNPJ == "00000000000")
                return false;

            String cnpjNums = String.Empty;

            Int32[] firstMultipliers = new Int32[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            Int32 sum = 0;

            for (Int32 i = 0; i < CNPJ.Length-2; i++)
                sum += Convert.ToInt32(firstMultipliers[i] * Convert.ToUInt32(CNPJ[i].ToString()));

            Int32 firstVerifyingDigit = (sum % 11) < 2 ? 0 : 11 - sum % 11;
            if (CNPJ[12].ToString() != firstVerifyingDigit.ToString())
                return false;

            Int32[] secondMultipliers = new Int32[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            sum = 0;

            for (Int32 i = 0; i < CNPJ.Length - 1; i++)
                sum += Convert.ToInt32(secondMultipliers[i] * Convert.ToUInt32(CNPJ[i].ToString()));

            Int32 secondVerifyingDigit = (sum % 11) < 2 ? 0 : 11 - sum % 11;
            if (CNPJ[13].ToString() != secondVerifyingDigit.ToString())
                return false;

            return true;
        }

        public static Boolean ValidateCellphone(String phone)
        {
            if (phone.Length != 9 && phone.Length != 11 && phone.Length != 13 && phone.Length != 14)
                return false;

            if (!IsNumber(phone))
                return false;

            if (phone.Length == 9)
            {
                if (!(ValidateNineDigit(phone[0].ToString())))
                    return false;
            }
            if (phone.Length == 11)
            {
                String DDD = phone.Substring(0, 2);

                if (!ValidateDDD(DDD))
                    return false;

                if (!(ValidateNineDigit(phone[2].ToString())))
                    return false;
            }
            else if(phone.Length == 13)
            {
                String brazilCountry = phone.Substring(0, 2);

                if (!ValidateBrazilCountry(brazilCountry))
                    return false;

                String DDD = phone.Substring(2, 2);

                if (!ValidateDDD(DDD))
                    return false;

                if (phone[4].ToString() != "9")
                    return false;

                if (!(ValidateNineDigit(phone[4].ToString())))
                    return false;
            }
            else if (phone.Length == 14)
            {
                String brazilCountry = phone.Substring(0, 2);

                if (!ValidateBrazilCountry(brazilCountry))
                    return false;

                String DDD = phone.Substring(2, 3);

                if (!ValidateDDD(DDD))
                    return false;

                if (!(ValidateNineDigit(phone[5].ToString())))
                    return false;
            }

            return true;
        }

        private static Boolean ValidateBrazilCountry(String countryCode)
        {
            if (countryCode != "55")
                return false;

            return true;
        }

        private static Boolean ValidateNineDigit(String digit)
        {
            if (digit != "9")
                return false;

            return true;
        }

        private static Boolean ValidateDDD(String DDD)
        {
            if(DDD.Length == 3)
            {
                if (
                        !DDD.Contains("011") && !DDD.Contains("012") && !DDD.Contains("013") && !DDD.Contains("014") &&
                        !DDD.Contains("015") && !DDD.Contains("016") && !DDD.Contains("017") && !DDD.Contains("018") &&
                        !DDD.Contains("019") && !DDD.Contains("021") && !DDD.Contains("022") && !DDD.Contains("024") &&
                        !DDD.Contains("027") && !DDD.Contains("028") && !DDD.Contains("031") && !DDD.Contains("032") &&
                        !DDD.Contains("033") && !DDD.Contains("034") && !DDD.Contains("035") && !DDD.Contains("037") &&
                        !DDD.Contains("038") && !DDD.Contains("041") && !DDD.Contains("042") && !DDD.Contains("043") &&
                        !DDD.Contains("044") && !DDD.Contains("045") && !DDD.Contains("046") && !DDD.Contains("047") &&
                        !DDD.Contains("048") && !DDD.Contains("049") && !DDD.Contains("051") && !DDD.Contains("053") &&
                        !DDD.Contains("054") && !DDD.Contains("055") && !DDD.Contains("061") && !DDD.Contains("062") &&
                        !DDD.Contains("063") && !DDD.Contains("064") && !DDD.Contains("065") && !DDD.Contains("066") &&
                        !DDD.Contains("067") && !DDD.Contains("068") && !DDD.Contains("069") && !DDD.Contains("071") &&
                        !DDD.Contains("073") && !DDD.Contains("074") && !DDD.Contains("075") && !DDD.Contains("077") &&
                        !DDD.Contains("079") && !DDD.Contains("081") && !DDD.Contains("082") && !DDD.Contains("083") &&
                        !DDD.Contains("084") && !DDD.Contains("085") && !DDD.Contains("086") && !DDD.Contains("087") &&
                        !DDD.Contains("088") && !DDD.Contains("089") && !DDD.Contains("091") && !DDD.Contains("092") &&
                        !DDD.Contains("093") && !DDD.Contains("094") && !DDD.Contains("095") && !DDD.Contains("096") &&
                        !DDD.Contains("097") && !DDD.Contains("098") && !DDD.Contains("099")
                   )
                    return false;
            }

            if (
                        !DDD.Contains("11") && !DDD.Contains("12") && !DDD.Contains("13") && !DDD.Contains("14") &&
                        !DDD.Contains("15") && !DDD.Contains("16") && !DDD.Contains("17") && !DDD.Contains("18") &&
                        !DDD.Contains("19") && !DDD.Contains("21") && !DDD.Contains("22") && !DDD.Contains("24") &&
                        !DDD.Contains("27") && !DDD.Contains("28") && !DDD.Contains("31") && !DDD.Contains("32") &&
                        !DDD.Contains("33") && !DDD.Contains("34") && !DDD.Contains("35") && !DDD.Contains("37") &&
                        !DDD.Contains("38") && !DDD.Contains("41") && !DDD.Contains("42") && !DDD.Contains("43") &&
                        !DDD.Contains("44") && !DDD.Contains("45") && !DDD.Contains("46") && !DDD.Contains("47") &&
                        !DDD.Contains("48") && !DDD.Contains("49") && !DDD.Contains("51") && !DDD.Contains("53") &&
                        !DDD.Contains("54") && !DDD.Contains("55") && !DDD.Contains("61") && !DDD.Contains("62") &&
                        !DDD.Contains("63") && !DDD.Contains("64") && !DDD.Contains("65") && !DDD.Contains("66") &&
                        !DDD.Contains("67") && !DDD.Contains("68") && !DDD.Contains("69") && !DDD.Contains("71") &&
                        !DDD.Contains("73") && !DDD.Contains("74") && !DDD.Contains("75") && !DDD.Contains("77") &&
                        !DDD.Contains("79") && !DDD.Contains("81") && !DDD.Contains("82") && !DDD.Contains("83") &&
                        !DDD.Contains("84") && !DDD.Contains("85") && !DDD.Contains("86") && !DDD.Contains("87") &&
                        !DDD.Contains("88") && !DDD.Contains("89") && !DDD.Contains("91") && !DDD.Contains("92") &&
                        !DDD.Contains("93") && !DDD.Contains("94") && !DDD.Contains("95") && !DDD.Contains("96") &&
                        !DDD.Contains("97") && !DDD.Contains("98") && !DDD.Contains("99")
                   )
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

