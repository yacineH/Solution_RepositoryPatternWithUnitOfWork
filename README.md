# Solution_RepositoryPatternWithUnitOfWork

La solution est composé de trois couches (API + EFCore + Core (domain)) .
La solution est implementé avec le pattern Repository Core comprend notre domain avec deux class (Author et Book).
Ajout d'une couche UnitOfWork qui permet de gerer les conexions a la base en une seule unite de travail dans notre cas Dbcontext avec ces repositories
ainsi la persistence de la data passe par unit of work et permet la liberation de dbcontext de la memoire avec Idisposable.
