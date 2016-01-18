# cegiddbselect
Outil qui sélectionne un goupe de bases Cegid avant le lancement des applis.

Dans un environnement Education avec TP, la duplication des bases Cegid est très utilisée par les enseignants.
On atteint vit la limite des 64ko du fichier INI chargé de lister les bases disponibles sur le serveur.

### Principe
- Eclater le fichier .ini en plusieurs fichiers plus petits. Le regroupement par professeurs s'avère le mieux adapté
- Ces fichiers se trouvent dans le même dossier que CegidPGI.ini du serveur. Il sont de la forme : Cegid_T_n.ini. T= teacher, n= un numéro associé au professeur. Dans le but d'anonymiser les fichiers.
- L'outil permet de sélectionner le fichier INI choisi et de le recopier à la place du CegidPGI.ini.
- Lancer l'outil avant chaque lancement de Cegid pour travailler avec les bases choisies.

### Avantages
- Palie au problème d'un fichier INI > 64ko tout en conservant 1 seul serveur
- Réduit la liste des bases des clients Cegid, pour une meilleur visibilité
- génère Un fichier .exe compatilbe .NET 3.5 sans aucune autre dépendance ni installation

### Versions client et serveur
- La version client recopie en local le fihcier .ini choisi à partir du partage
- La version serveur permet de travailler avec l'outil d'administration des bases et de mettre à jour le fichier Ini de l'enseignant.

### Compilation
- Modifer le fichiers TeacherDef.cs pour l'adapater aux besoins du site
- La configuration Debug génère la version Serveur
- La configuration Debug_Client génère la version client