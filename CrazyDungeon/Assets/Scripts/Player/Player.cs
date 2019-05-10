using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public int lifePoints = Constants.LIFE_POINTS;
	private static Player instance = null;

    private Player() {
    }

    public static Player Instance {
        get {
            if (instance == null) {
                instance = new Player();
            }
            return instance;
        }
    }

	public void doDamage(int damage) {
		lifePoints -= damage;
	}

	public void restartLife() {
		lifePoints = Constants.LIFE_POINTS;
	}
}
