# GazeVR 

### Auteurs 
Erwan AZZOUG - erwan.azzoug@etu.univ-nantes.fr
Siyuan LI  - siyuan.li@etu.univ-nantes.fr

### Tuteurs
Matthieu PERREIRA DA SILVA - matthieu.perreiradasilva@univ-nantes.fr
Toinon VIGIER - toinon.vigier@univ-nantes.fr

### Introduction 

Le but de ce projet est de proposer des solutions de visualisation des données oculométriques obtenues dans un environnement de réalité virtuelle. Le développement du projet se base sur Unity et le casque de réalité virtuelle HTC accompagné du dispositif d'Eye-Tracking de SMI. Cependant, des données sont chargés depuis des fichiers (dans la v0 seulement en CSV), il n'est donc pas obligatoire que les données aient été obtenues avec ces technologies. Nous avons créé un outil améliorable et modulable permettant d'ajouter, dans n'importe quel projet Unity 3D, la visualisation de données oculométriques qui auront été au préalable récupérées.

### Architecture 

- **Gaze.cs** : Classe représentant les données oculométriques temporelles et spatiales  de l'utilisateur
- **GazeRenderer.cs** : Classe permettant d'afficher et de gérer le comportement des visualisations. Elle est abstraite, il faut créer une classe qui l'hérite afin de personnaliser l'affichage et le comportement de la visualisation.
- Tous les fichiers **<name>GazeRenderer.cs** : Classe héritant de **GazeRenderer** et gérant le comportement d'une visualisation.
- **DataManager.cs** : GameObject gérant le chargement des données (en utilisant une interface **ILoader**), l'affichage des données (avec une liste de **GazeRenderer**) et le filtrage de ces dernières. Elle gère aussi, dans la v0, le comportement de l'interface utilisateur.
- **ILoader.cs** : Interface qui organise la gestion du chargement des données dans la scène. Elle est à implémenter pour créer son propre gestionnaire de chargement de données.
- **CSVLoader.cs** : Implémentation de l'interface ILoader permettant de charger des données CSV.
- **MovableCamera.cs** : Script permettant de bouger la caméra dans le mode *game*.
- **BadCSVToGoodCSV.py** : Programme en python qui permet d'améliorer la qualité des fichiers CSV qui nous avaient été fournis dans un premier temps. Nous avons ensuite créé notre propre package pour récupérer les données **datacollector.unitypackage**.




### Utilisation de l'outil

#### Importation/Exportation du projet

Pour exporter le projet :

1. Sélectionner dans le dossier *Prefabs/* le prefab **GazeVR** et les différents prefabs du type "GazeRenderer". Si vous souhaitez avoir la caméra inclue dans le projet, sélectionnez-la.
2. Faîtes un clic droit et sélectionner "Export Package...", vérifiez bien que tout est coché et cliqué sur "Export...".
3. Choisissez où vous voulez mettre le fichier .unitypackage (ça peut être n'importe où sur votre ordinateur).

Pour importer le projet :

1. Lancez le projet voulu dans l'éditeur de Unity.
2. Faîtes un clic droit dans le navigateur de fichier de Unity et choisissez "Import Package > Custom Package...".
3. Choisissez le fichier .unitypackage que vous avez exporté précédemment. Vérifiez que tout est bien coché. 
4. Cliquez-glissez le prefab **GazeVR** dans la scène et paramétrez **DataManager**.
5. (Pour CSVLoader) Créez un dossier *Data/* et mettez-y les fichiers csv des données oculométriques que vous avez.
6. (Optionnel) Supprimez la/les caméra(s) présente(nt) dans la scène pour mettre **MovableCamera** et ainsi pouvoir bouger de manière omnisciente dans la scène en mode *Game*. Sinon supprimez **MovableCamera** de l'arborescence de **GazeVR**.

#### Paramétrer DataManager

DataManager se paramètre depuis l'*Inspector* de l'éditeur de Unity. Le but de cet outil est de pouvoir facilement modifier la façon dont on affiche les données et de les filtrer facilement. 

- Gaze Renderer Prefabs : Liste des enfants de GazeRenderer qu'on va utiliser pour visionner les données oculométriques. On peut en mettre plusieurs superposées. Une fois que l'on a choisi le nombre de GazeRenderer que l'on veut utiliser, cliquez-glissez les prefabs directement dans les encoches prévues à cet effet.
- (Debug) Render Every : Ce paramètre permet de nettoyer les données. Lorsqu'on lui donne la valeur *n* (un entier), on ne récupère ainsi que toutes les *n* lignes. 

#### Lancer l'outil

Lorsque vous avez mis vos données dans le dossier *Data/* et que vous avez paramétré **DataManager**, vous pouvez cliquer sur le bouton Play de l'éditeur Unity. A partir de ce moment-là, les données se chargeront dans la scène. 

On peut filtrer la scène temporellement en utilisant les sliders. Pour filtrer la scène en fonction des utilisateurs étudiés, il suffit de désactiver les gameobjects représentant les utilisateurs. 

#### Pistes d'amélioration 

Filtrage des visualisations (regrouper les même visualisation d'un même utilisateur)

Faire un slider à 2 têtes

Détecter les fixations et les saccades

Rajouter des visualisations

Augmenter l'indépendance entre le chargeur de données et l'afficheur de données