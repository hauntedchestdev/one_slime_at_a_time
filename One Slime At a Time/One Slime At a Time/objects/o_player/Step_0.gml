right_key = keyboard_check(ord("D"));
left_key = keyboard_check(ord("A"));
up_key = keyboard_check(ord("W"));
down_key = keyboard_check(ord("S"));

//get xspeed and yspeed
xspeed = (right_key - left_key) * move_speed;
yspeed = (down_key - up_key) * move_speed;

//set sprite
if xspeed > 0 {face_direction = RIGHT};
if xspeed < 0 {face_direction = LEFT};

if yspeed > 0 {face_direction = DOWN};
if yspeed < 0 {face_direction = UP};

sprite_index = sprite[face_direction];

//collisions
if place_meeting(x+xspeed, y, o_overgrown_boulder)
{
	xspeed = 0;
}
if place_meeting(x, y+yspeed, o_overgrown_boulder)
{
	yspeed = 0;
}
if place_meeting(x+xspeed, y, o_overgrown_rocks)
{
	xspeed = 0;
}
if place_meeting(x, y+yspeed, o_overgrown_rocks)
{
	yspeed = 0;
}
if place_meeting(x+xspeed, y, o_overgrown_pebbles)
{
	xspeed = 0;
}
if place_meeting(x, y+yspeed, o_overgrown_pebbles)
{
	yspeed = 0;
}

//move the player
x += xspeed;
y += yspeed;


