using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaCrud.Modelo
{
    internal class Caixa
    {
        public int Id_cai { get; set; }
        public double SaldoInicial_cai { get; set; }
        public double TotalEntradas_cai { get; set; }
        public double TotalSaidas_cai { get; set; }
        public string Status_cai { get; set; }
        public double Total_cai { get; set; }
        public Funcionario funcionario { get; set; }

        public Caixa() { }

        public Caixa(double saldoI, double entradas, double saidas,string status, Funcionario fun)
        {
            if (saldoI >= 0) { this.SaldoInicial_cai = saldoI; } else { throw new Exception("Erro"); }

            this.Status_cai = status;
            this.funcionario = fun;
            this.TotalEntradas_cai = entradas;
            this.TotalSaidas_cai = saidas;
            funcionario.Id_fun = fun.Id_fun;
        }

        public override string ToString()
        {
            return $"========= CAIXA {Id_cai} =========\nid: " + Id_cai + "\nsaldo inicial: " + SaldoInicial_cai + "\nEntradas: " + TotalEntradas_cai + "\nSaidas: " + TotalSaidas_cai + "\nstatus: " + Status_cai + "\nFuncionario: " + funcionario.Nome_fun;
        }
    }
}
