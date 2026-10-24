# Journal

- 2026-10-24 | nouvelle demande | Forker Tyrrrz/YoutubeDownloader pour un usage scolaire, refaire l'interface, proposer des fonctionnalités manquantes
- 2026-10-24 | fork | appweb514-svg/YoutubeDownloader créé et cloné dans ~/orca/projects/YoutubeDownloader (branche par défaut amont : prime)
- 2026-10-24 | branche | feature/interface-ecole : interface « Vidéothèque », réglages Établissement, correctif cookie SOCS
- 2026-10-24 | bug | « Video watch page is broken » : cookie de consentement SOCS codé en dur dans YoutubeExplode 6.6.2 et périmé ; contourné côté app (Tyrrrz/YoutubeDownloader#909, Tyrrrz/YoutubeExplode#975)
- 2026-10-24 | PR | Draft appweb514-svg/YoutubeDownloader#1 (feature/interface-ecole → prime) : interface école + correctif SOCS — https://github.com/appweb514-svg/YoutubeDownloader/pull/1
- 2026-10-24 | nouvelle demande | Mettre en place les 10 fonctionnalités proposées (plan : .project/PLAN-fonctionnalites-ecole.md)
- 2026-10-24 | implémentation | 10 fonctionnalités livrées sur feature/interface-ecole ; bug corrigé : découpage FFmpeg en échec sur les MP4 avec sous-titres intégrés (-c:s copy)
- 2026-10-24 | demande | Suppression de l'avertissement « build instable » au démarrage
- 2026-10-24 | demande | Mises à jour automatiques désactivées (pointaient vers Tyrrrz/YoutubeDownloader)
- 2026-10-24 | demande | Renommer l'app en « Youtube4School » (titre de fenêtre, nom du bundle macOS ; assembly inchangé)
- 2026-10-24 | demande | Thèmes de couleur au choix dans les paramètres (Bleu école, Vert nature, Océan, Lavande, Coucher de soleil, Classique), en clair et sombre
