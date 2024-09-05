using CaixaCrud.DAO;
using CaixaCrud.Modelo;

/*
try
{
    Funcionario funcionario = new Funcionario();
                funcionario.Id_fun = 1;
                Caixa caixa = new Caixa(100, 20, 0,"ativo", funcionario);
                CaixaDAO caixaDAO = new CaixaDAO();

                caixaDAO.Insert(caixa);
                Console.WriteLine("Caixa inserido com sucesso");
}catch(Exception ex)
{
    Console.WriteLine(ex.Message );
}
*/


/*
try
{
    Caixa caixa = new Caixa();

    CaixaDAO caixaDao = new CaixaDAO();

    caixa.Id_cai = 2;

    caixaDao.Delete(caixa);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
*/

/*
try
{
    Funcionario funcionario = new Funcionario();
    funcionario.Id_fun = 2;
    Caixa caixa = new Caixa();
    caixa.Id_cai = 1;
    caixa.SaldoInicial_cai = 200;
    caixa.TotalEntradas_cai = 100;
    caixa.TotalSaidas_cai = 20;
    caixa.Status_cai = "fechado";
    caixa.funcionario = funcionario;

    CaixaDAO caixaDao = new CaixaDAO();

    caixaDao.Update(caixa);  
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*
try
{
    CaixaDAO caixaDao = new CaixaDAO();

    List<Caixa> caixa = caixaDao.List();

    foreach (Caixa a in caixa)
    {
        Console.WriteLine(a);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/



string op = "0";

do
{
    Console.Clear();
    Console.Write($@"=================== MENU ===================

1. Inserir Caixa
2. Deletar Caixa
3. Atualizar Caixa
4. Listar Caixas
5. Fechar Aplicação

Escolha uma das opções acima digitando seu número: ");

    op = Console.ReadLine();

    switch (op)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("=================== INSERIR CAIXA ===================");
            Console.WriteLine("\nA seguir digite as informações necessárias: ");
            Console.Write("\nSaldo Inicial: ");
            double saldoI = Convert.ToDouble(Console.ReadLine());
            Console.Write("Total de Entradas: ");
            double totalE = Convert.ToDouble(Console.ReadLine());
            Console.Write("Total de Saidas: ");
            double totalS = Convert.ToDouble(Console.ReadLine());
            Console.Write("Status(ativo ou fechado): ");
            string status = Console.ReadLine();

            Console.WriteLine("\n>>>>>>>>>> MENU DE FUNCIONÁRIOS <<<<<<<<<<\n");
            Console.Write(@"Selecione o Funcionário responsável pelo caixa

1. Eduardo
2. Elias
3. Kamila

Escolha uma das opções: ");


            int func = Convert.ToInt32(Console.ReadLine());

            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Id_fun = func;
                Caixa caixa = new Caixa(saldoI, totalE, totalS, status, funcionario);
                CaixaDAO caixaDAO = new CaixaDAO();

                caixaDAO.Insert(caixa);
                Console.WriteLine("\nCaixa inserido com sucesso!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu."); 
            Console.ReadKey();

            break;

        case "2":
            Console.Clear();
            Console.WriteLine("=================== DELETAR CAIXA ===================");
            Console.Write("\nA seguir digite o id do caixa que deseja excluir: ");
            int id  = Convert.ToInt32(Console.ReadLine());

            try
            {
                Caixa caixa = new Caixa();

                CaixaDAO caixaDao = new CaixaDAO();

                caixa.Id_cai = id;

                caixaDao.Delete(caixa);

                Console.WriteLine("Caixa excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            break;

        case "3":
            Console.Clear();
            Console.Clear();
            Console.WriteLine("=================== ATUALIZAR CAIXA ===================");
            Console.Write("\nDigite o id do caixa que deseja atualizar: ");
            int idAT = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n\nA seguir digite as informações do caixa para atualiza-lás ");
            Console.Write("\nSaldo Inicial: ");
            double saldoIAT = Convert.ToDouble(Console.ReadLine());
            Console.Write("Total de Entradas: ");
            double totalEAT = Convert.ToDouble(Console.ReadLine());
            Console.Write("Total de Saidas: ");
            double totalSAT = Convert.ToDouble(Console.ReadLine());
            Console.Write("Status(ativo ou fechado): ");
            string statusAT = Console.ReadLine();
            Console.WriteLine("\n>>>>>>>>>> ATUALIZAR RESPONSÁVEL <<<<<<<<<<\n");
            Console.Write(@"Selecione o Funcionário responsável pelo caixa

1. Eduardo
2. Elias
3. Kamila

Escolha uma das opções: ");

            int funcAT = Convert.ToInt32(Console.ReadLine());

            try
            {
                Funcionario funcionarioAT = new Funcionario();
                funcionarioAT.Id_fun = funcAT;
                Caixa caixa = new Caixa();
                caixa.Id_cai = idAT;
                caixa.SaldoInicial_cai = saldoIAT;
                caixa.TotalEntradas_cai = totalEAT;
                caixa.TotalSaidas_cai = totalSAT;
                caixa.Status_cai = statusAT;
                caixa.funcionario = funcionarioAT;

                CaixaDAO caixaDao = new CaixaDAO();

                caixaDao.Update(caixa);

                Console.WriteLine("\nCaixa atualizado com sucesso!"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu."); 
            Console.ReadKey();
            break;
            
        case "4":
            Console.Clear();
            Console.WriteLine("=================== LISTAGEM DE CAIXAS ===================\n");

            try
            {
                CaixaDAO caixaDao = new CaixaDAO();

                List<Caixa> caixa = caixaDao.List();


                
                foreach (Caixa a in caixa)
                {
                    a.Total_cai = a.SaldoInicial_cai + a.TotalEntradas_cai - a.TotalSaidas_cai;
                    Console.WriteLine(a.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            break;

        case "5": 
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine(">>>>>>>Número inválido!<<<<<<<\n\nPressione enter para retornar ao menu");
            break;
    }

}while (op != "5");
