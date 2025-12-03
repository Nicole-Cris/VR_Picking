<h1 align="center">📦 Gestão de Picking usando Realidade Virtual 📦</h1>
<div align="center"> <img src="https://img.shields.io/badge/Unity-2022+-black?logo=unity" /> <img src="https://img.shields.io/badge/Plataforma-VR-blue" /> <img src="https://img.shields.io/badge/Status-Concluidogreen" /> </div> <br>


Este projeto implementa um sistema de identificação automática de caixas e prateleiras em um ambiente 3D/VR para simulações logísticas.

## 📖 Índice

- [Visão Geral](#visão-geral)
- [Funcionalidades principais](#funcionalidades-principais)
- [Estrutura do projeto](#configuração-do-ambiente)
- [Como Funciona](#como-contribuir)
- [Demonstração](#demonstração)
- [Resultados e Comportamento](#resultados)
- [Dificuldades encontradas](#dificuldades)
- [Autor](#autor)

## 🔭 Visão Geral

Este projeto implementa um sistema de identificação automática de caixas e prateleiras em um ambiente 3D/VR para simulações logísticas.
Com base em um arquivo externo (list.json), o sistema:

✔️ Lê pares (Caixa, Prateleira)

✔️ Pisca as caixas válidas

✔️ Destaca a prateleira correspondente

✔️ Atualiza tudo dinamicamente sem recompilar o projeto

Ideal para treinamentos, simulações de armazém, onboarding de operadores e validação de layout.

## ✨ Funcionalidades principais

- Leitura dinâmica de configurações via StreamingAssets/list.json

- Piscar caixas associadas à prateleira correta

- Destacar prateleiras de forma permanente quando possuem caixas válidas

- Integração simples com UI e eventos do Unity

- Compatível com VR, incluindo Quest, PCVR e simuladores


 ## 📁 Estrutura do projeto

  ```
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
   ```

## 🧠 Como funciona

1. O arquivo list.json contém entradas no formato:
```
{
  "identifiers": [
    "Caixa1,WP_001",
    "Caixa2,WP_001",
    "Caixa7,WP_004"
  ]
}
```
2. O sistema interpreta cada linha como um par:

- **CaixaX** → tag da caixa

- **WP_XXX** → tag da prateleira

3. O BlinkManager_External:

  - Busca prateleiras pela tag
  
  - Busca caixas pela tag
  
  - Verifica se a caixa realmente está dentro da prateleira via IsChildOf
  
  - Se válida:
  
      - a caixa começa a piscar
  
      - a prateleira fica permanentemente amarela

4. Alterou o JSON?
➡️ O comportamento muda automaticamente sem recompilar nada.

## 🎥 Demonstração




## 🧪 Resultados e Comportamento

  - O sistema identificou corretamente todas as associações válidas.
  
  - A checagem por hierarquia (IsChildOf) impediu falsos positivos.
  
  - A performance manteve-se estável mesmo com dezenas de objetos.
  
  - A visualização foi clara e intuitiva:
  
  - caixas piscando → fácil de localizar
  
  - prateleira destacada → entendimento imediato do contexto

## 🚧 Dificuldades encontradas

- Necessidade de nomes/tags corretos para evitar erros de busca

- Dependência da hierarquia dos objetos (caixa deve ser filha da prateleira)

- Cuidados com materiais compartilhados (instanciar Material se necessário)

- Uso incorreto do JSON pode gerar pares inválidos


## 👩‍💻 Autor

Nicole Cristine — Desenvolvimento, lógica, documentação
