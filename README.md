## ValenceRD

Application WinForms de gestion R&D (Valence RD).

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
cd TON_REPO
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

Ce dépôt est hébergé sur GitHub (`https://github.com/alxmorel/TON_REPO`).

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

N’hésite pas à mettre à jour ce README si tu changes la façon de gérer la connexion, la BD, ou les scripts SQL.

