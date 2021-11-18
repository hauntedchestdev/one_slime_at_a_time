xspeed = 0;
yspeed = 0;

move_speed = 2;

state = PLAYERSTATE.FREE;
hit_by_attack = ds_list_create();

enum PLAYERSTATE{
	FREE,
	ATTACK_JAB,
	TRANSFORM_SLIME
	
}

sprite[RIGHT] = spr_normal_slime_right;
sprite[LEFT] = spr_normal_slime_left;
sprite[UP] = spr_normal_slime_up;
sprite[DOWN] = spr_normal_slime_down;

face_direction = DOWN;