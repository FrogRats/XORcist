VAR Show_NPC1 = false
VAR Show_NPC2 = false

-> Level_1_Outro_1

== Level_1_Outro_1 ==
As you watch your eccentric uncle byte the dust, you figure you might be rather well suited for this life ...
-> Level_2_Intro_1

== Level_2_Intro_1 ==
[RING RING]
-> Level_2_Intro_2

== Level_2_Intro_2 == 
~ Show_NPC1 = true
"HELLO?!? Jeb??? I need you to hurry over immediately! It's happened again ..."
-> Level_2_Intro_3

== Level_2_Intro_3 ==
"... Karl's gone bad again!"
-> Level_2_BadKarl_1

== Level_2_BadKarl_1 ==
~ Show_NPC1 = false
Looks like our journey has only just begun.
+ [This'll be easy] -> Level_2_BadKarl_2
+ [I might need a few more minutes ... ] -> Level_2_BadKarl_1

== Level_2_BadKarl_2 ==
~ Show_NPC2 = true
"You're not Jeb ... my brother really is pathetic if he thinks you're going to be the one to stop me." 

+ [Shut up and let me focus!] -> END
+ [Wow that's kinda mean dude] -> END