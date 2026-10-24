# Décisions

## 2026-10-24 — Interface « Vidéothèque » pour l'école
- Contexte : l'application doit être utilisable par des enseignants peu techniques.
- Décision : palette bleu/vert, en-tête avec nom de l'établissement, boutons avec libellés, guide en 3 étapes et rappel sur le droit d'auteur à l'écran vide, liste de téléchargements en cartes (miniature, titre, barre de progression), compteurs et actions groupées visibles (plus de menu contextuel caché). Traductions ajoutées en FR et EN ; les autres langues se rabattent sur l'anglais pour les nouveaux textes.
- Conséquences : `DashboardView.axaml` réécrit (DataGrid remplacé par ItemsControl) ; nouvelles clés de localisation dans la section « School ».

## 2026-10-24 — Dossier de téléchargement par défaut
- Contexte : en classe, choisir un dossier à chaque fois fait perdre du temps ; les écoles ont souvent un lecteur partagé.
- Décision : réglage `DefaultDownloadDirPath` ; s'il est défini, les dialogues d'enregistrement sont sautés (noms uniques garantis) et un bouton « Ouvrir le dossier » apparaît.
- Conséquences : si le dossier est vide, le comportement d'origine (demander à chaque fois) est conservé.

## 2026-10-24 — Contournement du cookie SOCS périmé
- Contexte : YoutubeExplode 6.6.2 envoie un cookie de consentement daté du 2025-10-03, expiré après 13 mois → redirection vers consent.youtube.com.
- Décision : `ConsentCookie.WithFreshConsent` génère un cookie à la date du jour, ajouté avant les cookies utilisateur (il remplace celui de la bibliothèque). Ne compte pas comme authentification.
- Conséquences : à retirer quand une version de YoutubeExplode intégrant Tyrrrz/YoutubeExplode#975 sera publiée.
