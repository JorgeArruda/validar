#!/usr/bin/env python3
# -*- coding: utf-8 -*-


class Validar():

    def CPF(self, cpf):
        cpf = str(cpf).replace(' ', '').replace('.', '').replace('-', '')
        print("len ", len(cpf))
        if (len(cpf) != 11 or self.VerificarIgualdade(cpf)):
            return False
        mult01 = [10, 9, 8, 7, 6, 5, 4, 3, 2]
        mult02 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2]

        resto = self.GetSomatorio(cpf[:9], mult01) % 11
        resto = 0 if resto < 2 else 11 - resto
        digito = str(resto)

        resto = self.GetSomatorio(cpf[:9]+digito, mult02) % 11
        resto = 0 if resto < 2 else 11 - resto
        digito = digito + str(resto)

        return cpf[9:] == digito

    def CNPJ(self, cnpj):
        cnpj = str(cnpj).replace(' ', '').replace(
            '.', '').replace('-', '').replace('/', '')
        print("len ", len(cnpj))
        if (len(cnpj) != 14 or self.VerificarIgualdade(cnpj)):
            return False
        mult01 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        mult02 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]

        resto = self.GetSomatorio(cnpj[:12], mult01) % 11
        resto = 0 if resto < 2 else 11 - resto
        digito = str(resto)

        resto = self.GetSomatorio(cnpj[:12]+digito, mult02) % 11
        resto = 0 if resto < 2 else 11 - resto
        digito = digito + str(resto)

        return cnpj[12:] == digito

    def PIS(self, pis):
        pis = str(pis).replace(' ', '').replace('.', '').replace('-', '')
        print("len ", len(pis))
        if (len(pis) != 11 or self.VerificarIgualdade(pis)):
            return False
        mult = [3, 2, 9, 8, 7, 6, 5, 4, 3, 2]

        resto = self.GetSomatorio(pis[:10], mult) % 11
        resto = 0 if resto < 2 else 11 - resto
        digito = str(resto)

        return pis[10:] == digito

    def GetSomatorio(self, array, mult):
        print(array, mult)
        array = str(array)
        mult = list(mult)
        resultado = 0
        for i in range(0, len(array)):
            resultado += int(array[i]) * mult[i]
        return resultado

    def VerificarIgualdade(self, valor):
        "Verifica se todos os caracteres de uma string são iguais."
        valor = str(valor)
        for i in range(1, len(valor)):
            if (valor[i-1] != valor[i]):
                return False
        return True


if (__name__ == "__main__"):
    val = Validar()
    cpf = "000.000.000-00"
    print("CPF: " + cpf + "   ", val.CPF(cpf))

    cnpj = "00.000.000/0011-95"
    print("Cnpj: " + cnpj + "   ", val.CNPJ(cnpj))

    pis = "111.11100.00-0"
    print("PIS: " + pis + "   ", val.PIS(pis))
