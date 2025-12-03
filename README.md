📦 VR Picking — Sistema de Identificação de Caixas e Prateleiras em Unity (Realidade Virtual)
<div align="center"> <img src="https://img.shields.io/badge/Unity-2022+-black?logo=unity" /> <img src="https://img.shields.io/badge/Plataforma-VR-blue" /> <img src="https://img.shields.io/badge/Status-Em desenvolvimento-green" /> </div> <br>

Este projeto implementa um sistema de identificação automática de caixas e prateleiras em um ambiente 3D/VR para simulações logísticas.
Com base em um arquivo externo (list.json), o sistema:

✔️ Lê pares (Caixa, Prateleira)
✔️ Pisca as caixas válidas
✔️ Destaca a prateleira correspondente
✔️ Atualiza tudo dinamicamente sem recompilar o projeto

Ideal para treinamentos, simulações de armazém, onboarding de operadores e validação de layout.

✨ Funcionalidades principais

🔍 Leitura dinâmica de configurações via StreamingAssets/list.json

📦 Piscar caixas associadas à prateleira correta

🟨 Destacar prateleiras de forma permanente quando possuem caixas válidas

🧩 Arquitetura modular, com scripts independentes:

Blinker

BlinkManager_External

ExternalListReader

🪄 Integração simples com UI e eventos do Unity

🕶️ Compatível com VR, incluindo Quest, PCVR e simuladores

📁 Estrutura do projeto
/Assets
  /Scripts
    Blinker.cs
    BlinkManager_External.cs
    ExternalListReader.cs
    TutorialStarter.cs
  /StreamingAssets
    list.json
  /Prefabs
    Caixa.prefab
    Prateleira.prefab

🧠 Como funciona

O arquivo list.json contém entradas no formato:

{
  "identifiers": [
    "Caixa1,WP_001",
    "Caixa2,WP_001",
    "Caixa7,WP_004"
  ]
}


O sistema interpreta cada linha como um par:

CaixaX → tag da caixa

WP_XXX → tag da prateleira

O BlinkManager_External:

Busca prateleiras pela tag

Busca caixas pela tag

Verifica se a caixa realmente está dentro da prateleira via IsChildOf

Se válida:

a caixa começa a piscar

a prateleira fica permanentemente amarela

Alterou o JSON?
➡️ O comportamento muda automaticamente sem recompilar nada.

🎥 Demonstração (GIF/Imagem)

(Coloque aqui um GIF do objeto piscando e da prateleira amarela)

🛠️ Tecnologias Utilizadas

Unity 2021/2022/2023

C# — programação e lógica de interação

StreamingAssets para leitura de arquivos externos

XR Interaction Toolkit (opcional)

Corrotinas para animações de piscar

📜 Exemplos de Uso
🔸 Atualizar o list.json
"Caixa3,WP_009"


Resultado:
✔ Caixa3 pisca
✔ A prateleira WP_009 fica amarela
✔ Nada mais é alterado

🔸 Simular um tutorial

O script TutorialStarter dispara tudo automaticamente ao entrar na cena.

🧪 Resultados e Comportamento

O sistema identificou corretamente todas as associações válidas.

A checagem por hierarquia (IsChildOf) impediu falsos positivos.

A performance manteve-se estável mesmo com dezenas de objetos.

A visualização foi clara e intuitiva:

caixas piscando → fácil de localizar

prateleira destacada → entendimento imediato do contexto

🚧 Possíveis Dificuldades

Necessidade de nomes/tags corretos para evitar erros de busca

Dependência da hierarquia dos objetos (caixa deve ser filha da prateleira)

Cuidados com materiais compartilhados (instanciar Material se necessário)

Uso incorreto do JSON pode gerar pares inválidos

📄 Referências (ABNT)

BORGES, Pablo Rodrigo et al. Treinamentos utilizando a realidade aumentada e virtual: comparação da inovação e tradicionalismo na formação profissional. Revista Observatório de la Economía Latinoamericana, 2019. Disponível em: https://dialnet.unirioja.es/servlet/articulo?codigo=9003937
.

NEXUS VR. Realidade aumentada na logística e cadeia de suprimentos. Disponível em: https://nexusvr.com.br/realidade-aumentada-na-logistica-e-cadeia-de-suprimentos/
.

MGI TECH. Como a realidade aumentada pode ser aplicada no setor logístico. Disponível em: https://blog.mgitech.com.br/blog/como-a-realidade-aumentada-pode-ser-aplicada-no-setor-logistico
.

👩‍💻 Autores

Nicole Cristine — Desenvolvimento, lógica, documentação

Colaboradores e testers do projeto VR Picking

Se quiser, posso gerar também:
