## ValenceRD

Application WinForms de gestion R&D (Valence RD).

### Vue d’ensemble du contexte métier

L’application est un outil interne de **gestion de la R&D pharmaceutique** pour des produits de santé (médicaments).  
Elle permet de suivre le **cycle de vie d’un produit** depuis sa création jusqu’aux essais précliniques (animaux) et cliniques (humains), en s’appuyant sur une base MySQL (`r_d_valence`).

L’objectif est de centraliser :
- la **définition de la recette / formulation** du produit,
- la **gestion des phases** (R&D, tests animaux, essais cliniques, etc.),
- la **traçabilité des essais** (paramètres, résultats, effets secondaires),
- la **gestion des ressources humaines** impliquées dans ces étapes.

--- 
       
### Prérequis

- **Système** : Windows
- **.NET / IDE**
  - Visual Studio (édition Community minimum)
  - Workload **“.NET desktop development”**
  - **.NET Framework 4.7.2**
- **Base de données**
  - MySQL Server (5.7 ou 8.x recommandé)
  - MySQL Workbench (ou équivalent) pour exécuter les scripts SQL
- **Git**
  - Git installé pour cloner le dépôt

---

### Récupération du projet

```bash
git clone https://github.com/alxmorel/ValenceRD.git
cd ValenceRD
```

Ouvrir ensuite le fichier `ValenceRD.csproj` dans Visual Studio.  
Les dépendances NuGet listées dans `packages.config` seront restaurées automatiquement (MySql.Data, iTextSharp, SSH.NET, etc.).

---

### Base de données

L’application utilise une base MySQL appelée `r_d_valence`.

#### 1. Création de la base et de l’utilisateur

1. Créer la base :

```sql
CREATE DATABASE r_d_valence CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

2. Créer l’utilisateur MySQL (config par défaut du projet) :

```sql
CREATE USER 'test'@'localhost' IDENTIFIED BY 'test';
GRANT ALL PRIVILEGES ON r_d_valence.* TO 'test'@'localhost';
FLUSH PRIVILEGES;
```

> Tu peux adapter l’utilisateur / mot de passe, mais il faudra alors modifier la chaîne de connexion dans `DBConnection.cs` (ou via `App.config` si tu mets ça en config).

#### 2. Scripts SQL

Il est recommandé d’organiser les scripts dans un dossier à la racine du dépôt, par exemple :

```text
database/
  schema/
    01_create_tables.sql
  seed/
    01_insert_initial_data.sql
```

Exécuter au minimum :

1. Les scripts de **création de tables** (dossier `schema/`).
2. Les scripts d’**insertion de données initiales** (dossier `seed/`).

---

### Connexion à la base

La connexion est centralisée dans `DBConnection.cs`.

Par défaut, le projet est configuré pour se connecter à MySQL en **localhost** avec :

- **Serveur** : `localhost`
- **Base** : `r_d_valence`
- **Utilisateur** : `test`
- **Mot de passe** : `test`

Si tu changes ces paramètres, adapte la chaîne de connexion en conséquence.

---

### Authentification / Connexion à l’application

Le point d’entrée de l’application est :

- `Program.Main` → lance le formulaire `Form_Connexion`.

Dans `Form_Connexion` :

- Le code d’authentification **Active Directory / LDAP** existe encore mais est **désactivé (commenté)**.
- La connexion actuelle repose sur un contrôle dans la base MySQL (table `login`, couple `user` + `password` chiffré).
- Si besoin, il est possible de simplifier la connexion (par exemple mode “sans mot de passe”) en modifiant la méthode `button2_Click` de `Form_Connexion` pour ouvrir directement `MainPageRDValence` après un contrôle minimal (par ex. juste un nom d’utilisateur non vide).

---

### Lancer le projet

1. Ouvrir la solution / le projet dans Visual Studio.
2. Vérifier que `ValenceRD` est bien le **projet de démarrage**.
3. **Build** la solution.
4. **Exécuter** (F5).

L’application affiche d’abord la fenêtre de connexion (`Form_Connexion`), puis, après authentification, la fenêtre principale (`MainPageRDValence`).

---

### Organisation des fichiers

- **Code C#**
  - Formulaires principaux : `Form1.cs`, `Form2.cs`, `Form3.cs`, `Form4.cs`, etc.
  - Formulaire de connexion : `Form_Connexion.cs`
  - Accès base de données : `DBConnection.cs`
- **Ressources UI**
  - Fichiers `.resx` associés aux formulaires (ex. `Form4.resx`) :
    - Ils sont **versionnés dans Git** (normal pour un projet WinForms).
- **Configuration**
  - `ValenceRD.csproj` : configuration du projet.
  - `App.config` : configuration .NET (potentiellement à utiliser pour externaliser la chaîne de connexion).
- **Dépendances**
  - `packages.config` : liste des packages NuGet (MySql.Data, iTextSharp, SSH.NET, etc.).
- **Base de données**
  - Dossier recommandé : `database/` avec sous-dossiers `schema/` et `seed/`.

---

### Git / GitHub

Ce dépôt est hébergé sur GitHub (`https://github.com/alxmorel/ValenceRD`).

Quelques commandes utiles :

```bash
# Vérifier l'état
git status

# Ajouter les changements
git add .

# Créer un commit
git commit -m "Message de commit"

# Pousser sur GitHub
git push origin master
```

---

### Objets métiers principaux

- **Produit**
  - Identifié par un `idProduit`, avec **nom scientifique** et **nom générique**.
  - Associé à un ou plusieurs **symptômes traités**.
  - Possède des **versions**, et progresse dans des **phases** (via la table de validation des phases).

- **Recette / Procédé de fabrication**
  - Décrit comment le produit est fabriqué :
    - **Nomenclature des ingrédients** (matières premières, quantités, unités).
    - **Étapes métier** : opérations successives avec libellé, durée, ordre.
  - La recette est saisie et éditée visuellement dans l’application, puis enregistrée en base.
  - Une version PDF de la recette peut être générée (pour archivage / communication).

- **Phases de développement**
  - Le produit passe par plusieurs **phases** (R&D, tests animaux, essais humains, etc.).
  - Chaque phase est tracée avec :
    - une date d’insertion,
    - une date de validation,
    - un **statut de validation**,
    - un **commentaire** décrivant l’avancement / les conclusions.

- **Ressources humaines**
  - Des **personnes** (ressources) peuvent être affectées à un produit et/ou à certaines étapes de la recette.
  - Pour chaque ressource, l’application stocke :
    - son identité (nom, prénom),
    - son **action / rôle**,
    - sa **charge de travail** sur la phase/recette.

- **Effets secondaires**
  - Pour un couple (produit, version, phase, essai), l’application permet de saisir des **effets secondaires** :
    - la **nature** de l’effet,
    - sa **fréquence**,
    - sa **gravité**.
  - Ces informations sont affichées et éditées dans des grilles avec des listes déroulantes (valeurs de référence).

- **Essais sur animaux**
  - Représentent les **tests précliniques** :
    - type de sujet (espèce animale),
    - voie d’administration,
    - effectif,
    - taux de réussite,
    - paramètres de pharmacocinétique,
    - commentaire,
    - statut (validé/terminé ou non).
  - Les effets secondaires observés pendant ces essais sont également saisis et liés au produit.

- **Essais cliniques humains**
  - Représentent les **tests cliniques** :
    - sexe, tranche d’âge, état du sujet,
    - présence ou non de placebo,
    - effectif, taux de réussite,
    - paramètres de pharmacocinétique (durée, intensité),
    - effets secondaires,
    - statut de l’essai.
  - Ces essais sont attachés à une phase et une version du produit, pour assurer la traçabilité réglementaire.

- **Authentification**
  - Historiquement, une authentification **Active Directory / LDAP** était prévue (désactivée dans le code actuel).
  - L’application utilise aujourd’hui une table `login` (couple utilisateur / mot de passe chiffré) dans la base MySQL.

---

### Processus métier global

1. **Création d’un nouveau produit**
   - Depuis l’écran de création, l’utilisateur saisit :
     - le **nom scientifique**,
     - le **nom générique**,
     - le **symptôme traité**.
   - Le système génère un nouvel `idProduit` et crée les entrées nécessaires en base (produit, symptôme traité, phase initiale).

2. **Élaboration de la recette en phase R&D**
   - L’utilisateur construit la **recette de fabrication** :
     - ajoute / supprime des ingrédients, définit quantités et unités,
     - décompose le procédé en **étapes** avec opérations et durées,
     - affecte des **ressources humaines**,
     - saisit un **commentaire de phase**.
   - La recette est sauvegardée et peut être **exportée en PDF** pour diffusion ou archivage.

3. **Passage aux phases successives**
   - Lorsque la phase R&D est jugée satisfaisante, l’utilisateur :
     - **valide la phase** (mise à jour du statut dans la table de validation),
     - déclenche le passage à la **phase suivante** (tests animaux).
   - Après les tests animaux, même logique pour le passage vers les **essais humains** :
     - validation de la phase précédente,
     - création / initialisation de la nouvelle phase dans la base.

4. **Gestion des essais (animaux et humains)**
   - Pour chaque produit / version :
     - l’utilisateur peut créer un ou plusieurs **tests animaux**, saisir leurs paramètres et résultats, et enregistrer les effets secondaires.
     - une fois ces tests terminés et validés, il peut créer des **essais cliniques humains**, structurés de façon similaire (paramètres, résultats, effets secondaires).
   - Chaque essai possède un **statut** (en cours, terminé/validé), reflété visuellement dans les grilles par une icône.
  
5. **Pilotage et consultation**
   - L’écran d’accueil liste l’ensemble des **produits** avec :
     - leur **phase courante**,
     - la **dernière version**,
     - les dates d’insertion / validation,
     - les symptômes traités.
   - Des **filtres** permettent de rechercher un produit par :
     - identifiant,
     - nom scientifique,
     - symptôme,
     - phase,
     - plages de dates.
   - Depuis cette vue, l’utilisateur navigue vers :
     - la création d’un nouveau produit,
     - l’upgrade de version,
     - le détail de la recette,
     - les tests animaux ou essais humains associés.
