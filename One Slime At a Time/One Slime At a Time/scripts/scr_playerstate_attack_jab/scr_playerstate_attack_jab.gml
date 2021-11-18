function scr_playerstate_attack_jab(){
	show_debug_message("Player has Jabbed!");
	xspeed = 0;
	yspeed = 0;
	
	//Start of the jab
	if(sprite_index != spr_jab_down_proto && yspeed > 0){
		sprite_index = spr_jab_down_proto;
		image_index = 0;
		ds_list_clear(hit_by_attack);
	}
	
	if(sprite_index != spr_jab_up_proto && yspeed < 0){
		sprite_index = spr_jab_up_proto;
		image_index = 0;
		ds_list_clear(hit_by_attack);
	}
	
	if(sprite_index != spr_jab_right_proto && xspeed > 0){
		sprite_index = spr_jab_right_proto;
		image_index = 0;
		ds_list_clear(hit_by_attack);
	}
	
	if(sprite_index != spr_jab_left_proto && xspeed < 0){
		sprite_index = spr_jab_left_proto;
		image_index = 0;
		ds_list_clear(hit_by_attack);
	}
	
	//Use attack hitbox & check for hits
	if(sprite_index == spr_jab_down_proto){
		mask_index = spr_jab_down_hitbox;
	}
	
	if(sprite_index == spr_jab_up_proto){
		mask_index = spr_jab_up_hitbox;
	}
	
	if(sprite_index == spr_jab_right_proto){
		mask_index = spr_jab_right_hitbox;
	}
	
	if(sprite_index == spr_jab_left_proto){
		mask_index = spr_jab_left_hitbox;
	}
	
	var hit_by_attack_now = ds_list_create();
	var hits = instance_place_list(x,y, o_overgrown_boulder, hit_by_attack_now, false);
	if (hits > 0 ){
		for(var i = 0; i < hits; i++){
			//If this instance has not yet been hit by this attack
			var hitID = hit_by_attack_now[| i];
			if(ds_list_find_index(hit_by_attack, hitID) == -1){
				ds_list_add(hit_by_attack, hitID);
				with (hitID){
					scr_boulder_hit(3);
				}
			}
		}
		
	}
	ds_list_destroy(hit_by_attack_now);
	mask_index = spr_normal_slime_down;
	
	if(animation_end()){
		sprite_index = spr_normal_slime_down;
		state = PLAYERSTATE.FREE;
	}
}