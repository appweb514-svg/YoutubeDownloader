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
- 2026-10-24 | demande | Suppression du message « Merci de soutenir l'Ukraine » affiché au premier lancement
- 2026-10-24 | demande | Finaliser la suite : en-tête adaptatif, .srt recalés sur les extraits, progression du découpage, traductions DE/ES/HU/UK/ZH, titre et description de la PR
- 2026-10-24 | bug | Erreur 403 (Forbidden) de YouTube à l'ajout d'une vidéo : 3 tentatives sur 403 et message d'erreur lisible au lieu de la pile d'appels
- 2026-10-24 | demande | Nom Youtube4School partout (exécutable/Dock/barre des tâches, menu macOS) et numéro de version retiré du titre
- 2026-10-24 | bug | Changement de couleur sans effet : la liste des palettes, recréée à chaque changement de réglage, renvoyait l'ancienne sélection ; liste construite une seule fois (vérifié en test headless avec captures)
- 2026-10-24 | demande | Version portable Windows sans droits administrateur : données à côté de l'exe (repli %LOCALAPPDATA%\Youtube4School), manifeste asInvoker, zip Youtube4School-portable.<rid>.zip avec LISEZMOI.txt
