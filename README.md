# Atelier
# Veuillez utilise le swagger pour les tests du site web
# Pour le point 1 - le endPoint est le /Players/GetPlayers
# Pour le point 2 - le endPoint est le /Players/GetPlayer/{id} avec le Id comme parem�tre
# Pour le point 3 - le endPoint est le /Players/GetPlayersStats
# Quelle pr�cisitions de mon c�t�:
#	J'ai utilis� les donn�es du fichier json qu'on retrouve sur le site comme donn�s de reference
#	Pour le pays qui a le plus grand ratio de parties gagn�es, j'ai utilis� les valeurs de la liste 'Last' et j'ai fait la logique suivant: 1 = victoire, 0 = d�faite
#	Pour le IMC, j'ai arrondi la valeur � 4 d�cimales
#	Je n'ai pu ajouter la classe de tests unitaires dans Git alors je l'ai mis en commentaire dans le projet. C'est la classe PlayerServiceTests