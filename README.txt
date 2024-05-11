Singleton => utiliser pour plusieurs instance (playerManager, timer, uiManager,
								 GameManager, ect...)

Pooling => Enemys, Scythe, XpOrbs

Observer => Ui, Timer, LvUp, death, pause

factory => pas utiliser mais cree pareil 
		(J'en utilise sort ove one mais n'est pas label comme factory)

Progression => utilisation d'ui pour lv up cest armes plus tard des stats aussi
			plusieurs waves d'enemy differentes + dure
			Xp

Qualiter element => manque de visuel et audio mais 
			musique de fond 
			bruit: mort enemy, click boutton
			sprite par objet pas d'animation
			sauvegarde settings audio => scriptable object


Controle
	axis donc	{
				wasd, manette
			}
	escape => pause

