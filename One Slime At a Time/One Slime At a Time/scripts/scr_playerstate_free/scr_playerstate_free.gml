
function scr_playerstate_free(){
	//get xspeed and yspeed
xspeed = (right_key - left_key) * move_speed;
yspeed = (down_key - up_key) * move_speed;

//set sprite
if xspeed > 0 {face_direction = RIGHT};
if xspeed < 0 {face_direction = LEFT};

if yspeed > 0 {face_direction = DOWN};
if yspeed < 0 {face_direction = UP};

sprite_index = sprite[face_direction];

if(transform_key){ state = PLAYERSTATE.TRANSFORM_SLIME;}

if(attack_key){ state = PLAYERSTATE.ATTACK_JAB;}


//collisions
if (place_meeting(x+xspeed, y, o_overgrown_boulder))
{
	while(!place_meeting(x+sign(xspeed), y, o_overgrown_boulder))
		x += sign(xspeed);
	xspeed = 0;
}

if (place_meeting(x, y + yspeed, o_overgrown_boulder))
{
	while(!place_meeting(x, y + sign(yspeed), o_overgrown_boulder))
		y += sign(yspeed);
	yspeed = 0;
}
if (place_meeting(x+xspeed, y, o_overgrown_rocks))
{
	while(!place_meeting(x+sign(xspeed), y, o_overgrown_rocks))
		x += sign(xspeed);
	xspeed = 0;
}

if (place_meeting(x, y + yspeed, o_overgrown_rocks))
{
	while(!place_meeting(x, y + sign(yspeed), o_overgrown_rocks))
		y += sign(yspeed);
	yspeed = 0;
}
if (place_meeting(x+xspeed, y, o_overgrown_pebbles))
{
	while(!place_meeting(x+sign(xspeed), y, o_overgrown_pebbles))
		x += sign(xspeed);
	xspeed = 0;
}

if (place_meeting(x, y + yspeed, o_overgrown_pebbles))
{
	while(!place_meeting(x, y + sign(yspeed), o_overgrown_pebbles))
		y += sign(yspeed);
	yspeed = 0;
}


//move the player
x += xspeed;
y += yspeed;


}