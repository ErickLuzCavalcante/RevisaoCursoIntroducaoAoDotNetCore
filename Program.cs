using System;

namespace RevisaoCursoIntroducaoAoDotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];

            string opcaoUsuario = obterOpcaoUsuario();
            int indiceAluno = 0;

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        if (indiceAluno < alunos.Length)
                        {
                            Console.WriteLine("Informe o nome do aluno");
                            Aluno aluno = new Aluno();
                            aluno.Nome = Console.ReadLine();
                            Console.WriteLine("Informe a nota do aluno");
                            if (decimal.TryParse(Console.ReadLine(), out var nota))
                            {
                                aluno.Nota = nota;
                            }
                            else
                            {
                                throw new ArgumentException("Valor da nota deve ser decimal");
                            }

                            alunos[indiceAluno] = aluno;
                            indiceAluno++;
                        }
                        else
                        {
                            Console.WriteLine("Numero maximo de alunos alcançado");
                            Console.ReadKey();
                        }


                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome}- NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        break;
                    default:
                        //throw new ArgumentOutOfRangeException();
                        break;
                }
                opcaoUsuario = obterOpcaoUsuario();
            }

        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine("\nInforme a opção desejada\n" +
            "1- Inserir novo aluno\n" +
            "2- Listar alunos\n" +
            "3- Calcular média geral\n" +
            "X- Sair\n\n"
            );

            return Console.ReadLine();
        }
    }
}
