# DistribuicaoLucros
Repositorio para o desafio - Distribuição de Lucros.


Desafio - Distribuição dos lucros

o desafio foi resolvido utilizando oque foi pedido no arquivo enviado.

alguns pontos importantes.

• foi considerado com salario minimo o salario minimo vigente no valor de R$1.100,00
• devido a uma ambiguidade no valor dos pesos onde o mesmo o valor "igual" nao se encaixava nem acima nem abaixo ou em mais ou em menos foi considerado a seguinte regra.            
CalcularPesoAdmissao

(tempo_de_casa <= 1) peso = 1;              
(tempo_de_casa > 1 && tempo_de_casa < 3) peso = 2;
(tempo_de_casa >= 3 && tempo_de_casa < 8) peso = 3;   
(tempo_de_casa >= 8)  peso 5 ;
                
CalcularPesoSalario

(numeros_salario_minimos <= 3) peso = 1;              
(numeros_salario_minimos > 3 && numeros_salario_minimos < 5) peso = 2;
(numeros_salario_minimos >= 5 && numeros_salario_minimos < 8) peso = 3;               
(numeros_salario_minimos >= 8)  peso 5;
                
para efetuar o teste sera necessario apenas executar o projeto via visual studio f5, voce sera redirecionado ao swagger e podera efetuar o teste pelo mesmo.

https://localhost:44342/swagger/index.html

ou 

https://localhost:44342/v1/BonusEmpresa/4100000.98
                
