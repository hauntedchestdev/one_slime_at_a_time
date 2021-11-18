right_key = keyboard_check(ord("D")) || keyboard_check(vk_right);
left_key = keyboard_check(ord("A")) || keyboard_check(vk_left);
up_key = keyboard_check(ord("W")) || keyboard_check(vk_up);
down_key = keyboard_check(ord("S")) || keyboard_check(vk_down);
attack_key = keyboard_check(ord("E"));
transform_key = keyboard_check(vk_enter);

switch (state)
{
	case PLAYERSTATE.FREE: scr_playerstate_free(); break;
	
	case PLAYERSTATE.ATTACK_JAB: scr_playerstate_attack_jab(); break;
	
	case PLAYERSTATE.TRANSFORM_SLIME: scr_playerstate_transform(); break;
}