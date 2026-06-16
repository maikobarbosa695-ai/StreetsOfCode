# 🏙️ Streets of Code — Jogo de Plataforma 2D

> Jogo de plataforma 2D desenvolvido na Unity como projeto da disciplina de Game Development — UniFECAF.

---

## 🎮 Sobre o Jogo

**Streets of Code** é um jogo de plataforma 2D ambientado em uma metrópole futurista e decadente. Você controla um jovem hacker que precisa atravessar 4 fases urbanas coletando chips de dados e desviando de drones de segurança.

---

## 🕹️ Controles

| Ação | Tecla |
|------|-------|
| Mover | A / D ou ← → |
| Pular | Espaço |
| Correr | Shift + A/D |
| Escalar | W / S nas escadas |
| Double Jump | Espaço (desbloqueado no Nível 2) |

---

## 📋 Mecânicas Implementadas

- ✅ Movimento com andar e correr
- ✅ Pulo com física via Rigidbody2D
- ✅ Double Jump (desbloqueado via PowerUp)
- ✅ Escalada em grades e escadas
- ✅ Sistema de vidas com período de invencibilidade
- ✅ Coletáveis com tipos diferentes (pontos, vida, power-up)
- ✅ Inimigos com patrulha automática
- ✅ HUD com pontuação e vidas
- ✅ Transição entre fases com fade
- ✅ Feedback visual e sonoro completo

---

## 🗺️ Fases

| Fase | Cenário | Novidade |
|------|---------|----------|
| 1 | Ruas da Cidade | Introdução, plataformas fixas |
| 2 | Becos e Vielas | Plataformas móveis, double jump |
| 3 | Telhados | Plataformas instáveis, projéteis |
| 4 | Metrô Subterrâneo | Tudo combinado + chefe final |

---

## 🛠️ Tecnologias

- **Engine:** Unity 2022.3 LTS
- **Linguagem:** C#
- **Assets:** itch.io (licença gratuita) + freesound.org (CC0)
- **Controle de versão:** Git + GitHub

---

## 📁 Estrutura do Projeto

```
Assets/
├── Scripts/
│   ├── PlayerController.cs
│   ├── PlayerHealth.cs
│   ├── CollectibleItem.cs
│   ├── EnemyPatrol.cs
│   ├── GameManager.cs
│   ├── AudioManager.cs
│   ├── UIManager_LevelLoader.cs
├── Sprites/
├── Audio/
├── Scenes/
│   ├── Menu.unity
│   ├── Fase1.unity
│   ├── Fase2.unity
│   ├── Fase3.unity
│   ├── Fase4.unity
│   └── MenuFinal.unity
└── Animations/
```

---

## ▶️ Como Executar

1. Baixe a pasta compactada `StreetsOfCode_Build.zip`
2. Extraia e execute `StreetsOfCode.exe` (Windows)
3. Ou abra o projeto no Unity 2022.3+ e pressione Play

---

## 👤 Autor

Desenvolvido como projeto acadêmico — Disciplina Game Development, UniFECAF.
