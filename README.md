# Padrao strategy

![padrão de projetos strategy](https://www.thiengo.com.br/img/post/normal/09j782i4d422a779bkf7907oi3950ab95fe613edf46f2c3cebb61d52d3.jpg)

Esse Padrão faz parte da gangue dos 4 (GoF) e é um padrao comportamental, ou seja, é um padrao usado em rotina de comportamento do sistema.
[Projeto de exemplo no github](https://github.com/Notim/Design-patterns-Strategy)

## Quando usar  

Quando se faz necessário usar muitas condições específicas para uma determinada tarefa ou regra de negócio.

## porque usar

é um padrão que evita que seja necessário vários ifs encadeados,
pois você aplica as regras específicas para cada tipo de problema em classes distintas.

## Como usar  

Criar uma interface que implemente metodos que será padrão para todos essas condicões específicas

## Problemas exemplos  

**_Realizador de investimentos_**:  
imagina que exista uma rotina que define qual vai ser a estrategia de intvestimento aplicado sobre um Saldo
e que existem estrategias diferentes de rendimento que dependem de qual perfil de investidor do cara que ta investindo.
Sendo: _Agressivo_, _Moderado_ e _conservador_.
cada um dos perfis tem regras de rendiment diferentes.
Foi criado uma iterface chamada `IInvestorProfileStrategy` e suas implementações: `ConservativeProfileStrategy`, `ModerateProfileStrategy` e `AggressiveProfileStrategy`

```CSharp
// Esse é o molde para as classes
public interface IInvestorProfileStrategy
{
    decimal calculate(BankAccount Account);
}
```

```CSharp
// essa é a entidade que vai ser usada nas estratégias
public class BankAccount
{
    public decimal Balance { get; set; }
}
```

Foram criadas as implementacoes de acordo com as regras de negócio específicas para cada um dos perfis.

> Regras para perfil Conservador: sempre rendera 6.5% do saldo

```CSharp
public class ConservativeProfileStrategy : IInvestorProfileStrategy
{
    public decimal calculate(BankAccount Account)
    {
        return (decimal) 0.065 * Account.Balance;
    }
}
```

> Regras para perfil Moderado: 50% de chance de render 25% e 50% de chance de render 15%

```CSharp
public class ModerateProfileStrategy : IInvestorProfileStrategy
{

    public decimal calculate(BankAccount Account)
    {
        bool choose = new Random().Next(100) > 50;

        return (decimal) (choose ? 0.25 : 0.15) * Account.Balance;
    }
}
```

> Regras para perfil Agressivo: 20% de chance de render 50%, 30% de chance de render 25% e 50% de chance de render 10%.

```CSharp
public class AggressiveProfileStrategy : IInvestorProfileStrategy
{
    public decimal calculate(BankAccount Account)
    {
        var choose = new Random().Next(100);
        var fator = (float) 0.0;
        if (choose <= 20) {
            fator = (float) 0.5;
        }
        if (choose > 20 && choose <= 30) {
            fator = (float) 0.25;
        }
        if (choose > 30) {
            fator = (float) 0.10;
        }

        return (decimal) (fator) * Account.Balance;
    }
}
```

Após definir as estratégias é necessário fazer a chamada dela de modo genérico, não especificando a estratégia a ser usada.

```CSharp
// aplicador de investimentos
public static class InvestmentDirector
{
    public static decimal Invest(BankAccount account, IInvestorProfileStrategy strategy)
    {

        var Income = strategy.calculate(account);

        // aqui é alicado uma regra global que diz que o rendimento idependente de como foi vai ser descontado 25% para impostos
        Income += (decimal) (0.75 * (double) Income);

        return Income;
    }
}
```

```CSharp
class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount {
            Balance = 500000
        };

        var AmmountConservetive = InvestmentDirector.Invest(account, new ConservativeProfileStrategy());
        var AmmountModerate     = InvestmentDirector.Invest(account, new ModerateProfileStrategy());
        var AmmountAggressive   = InvestmentDirector.Invest(account, new AggressiveProfileStrategy());

        Console.WriteLine("Start Value: " + account.Balance.ToString("C"));
        Console.WriteLine("Application Income for Conservetive: " + AmmountConservetive.ToString("C"));
        Console.WriteLine("Application Income for Moderate: " + AmmountModerate.ToString("C"));
        Console.WriteLine("Application Income for Aggressive: " + AmmountAggressive.ToString("C"));
    }
}
```

Saída no console com os perfis:

```Console
[notim@lenovo-ideapad: ~/GitHub/Notim/Design-patterns-Strategy/Investments]$ dotnet run
Start Value: R$ 500.000,00
Application Income for Conservetive: R$ 56.875,00
Application Income for Moderate: R$ 218.750,00
Application Income for Aggressive: R$ 437.500,00
```

**_Realizador de orcamento com Calculador de impostos_**.
imagina onde exista uma caralhada de tipos de impostos, e que basicamente ele faz a mesma coisa no final que é
ser somado no valor total de um orçamento. Foi criado uma interface chamada ITax que possui um metodo chamado Calcular. Pra cada tipo de imposto diferente você implementa a interface e usa o método pra realizar as regras inclusive usar recursos externos.

**Referencias:**  
[https://www.alura.com.br](https://www.alura.com.br/curso-online-design-patterns-dotnet)  
[http://www.linhadecodigo.com.br](http://www.linhadecodigo.com.br/artigo/3268/strategy-padrao-de-projeto-com-microsoft-net-csharp.aspx)  
[https://www.thiengo.com.br](https://www.thiengo.com.br/padrao-de-projeto-strategy-estrategia)