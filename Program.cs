using System;

namespace Validação
{
    class Program
    {
        static void Main(string[] args)
        {
            string cnpj = "61.022.851/0001-20";
            Console.Write("Cnpj: " + cnpj + "   " + ValidarCNPJ(cnpj).ToString());
            Console.ReadKey();

            string cpf = "611.022.851-20";
            Console.Write("CPF: " + cpf + "   " + ValidarCPF(cpf).ToString());
            Console.ReadKey();

            string pis = "250.96103.56-1";
            Console.Write("PIS: " + pis + "   " + ValidarPIS(pis).ToString());
            Console.ReadKey();
        }

        public static bool ValidarCNPJ(string cnpj)
        {
            cnpj = cnpj.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14 || VerificarIgualdade(cnpj))
                return false;
            string cnpj_temp = cnpj.Substring(0, 12);
            int[] mult01 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult02 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int resto = GetSomatorio(cnpj_temp, mult01) % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();
            cnpj_temp = cnpj_temp + digito;

            resto = GetSomatorio(cnpj_temp, mult02) % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto.ToString();
            Console.WriteLine("Digito: " + digito);
            return cnpj.EndsWith(digito);
        }

        public static bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(" ", "").Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) || VerificarIgualdade(cpf))
                return false;
            string cpf_temp = cpf.Substring(0, 9);
            int[] mult01 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult02 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int resto = GetSomatorio(cpf_temp, mult01) % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();
            cpf_temp = cpf_temp + digito;

            resto = GetSomatorio(cpf_temp, mult02) % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto.ToString();
            Console.WriteLine("Digito: " + digito);
            return cpf.EndsWith(digito);
        }

        public static bool ValidarPIS(string pis)
        {
            pis = pis.Replace(" ", "").Replace(".", "").Replace("-", "");
            if (pis.Length != 11 || VerificarIgualdade(pis))
                return false;
            string pis_temp = pis.Substring(0, 10);
            int[] mult = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int resto = GetSomatorio(pis_temp, mult) % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();

            Console.WriteLine("Digito: " + digito);
            return pis.EndsWith(digito);
        }

        public static int GetSomatorio(int[] array)
        {
            int resultado = 0;
            foreach (int valor in array)
                resultado += valor;
            return resultado;
        }

        public static int GetSomatorio(int[] array, int[] mult)
        {
            if (array.Length != mult.Length)
                return 0;
            int resultado = 0;
            for (int i = 0; i < array.Length; i++)
                resultado += array[i] * mult[i];
            return resultado;
        }

        public static int GetSomatorio(string array, int[] mult)
        {
            if (array.Length != mult.Length)
                return 0;
            int resultado = 0;
            for (int i = 0; i < array.Length; i++)
                resultado += int.Parse(array[i].ToString()) * mult[i];
            return resultado;
        }

        public static bool VerificarIgualdade(string valor)
        {
            for (int i = 1; i < valor.Length; i++)
                if (valor[i - 1] != valor[i])
                    return false;
            return true;
        }
    }
}
