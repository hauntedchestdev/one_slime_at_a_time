function scr_boulder_hit(){
	var _damage = argument0;
	
	hp -= _damage;
	flash = true;
	if (hp > 0){
		state = BOULDERSTATE.HIT;
		hitNow = true;
	}
	else {
		state = BOULDERSTATE.DEAD;
	}
}