using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public static int life = Constants.LIFE_POINTS;
	public static int experience = 0;
	public static int level = 1;

	public void gainExperience(int exp) {
		experience += exp;
		checkLevelUp();
	}

	private static void checkLevelUp() {
		for (int i=0; i < Constants.MAX_LEVEL; i++) {
			if (Constants.LEVEL_EXP[i] > experience) {
				if (i + i > level) {
					level++;
					break;
				}
			}
		}
	}

	public void doDamage(int damage) {
		life -= damage;
	}

	public void resetLife() {
		life = Constants.LIFE_POINTS;
	}
}
