VAR Show_NPC = false
VAR Show_NPC2 = false

-> Level_2_Outro_1

== Level_2_Outro_1 ==
... And just like that, Bad Karl and his moustache are no more ... 
-> Level_3_Intro_1

== Level_3_Intro_1 ==
[RING RING]
-> Level_3_Intro_2

== Level_3_Intro_2 == 
+ [.... Seriously?? it's not even been 5 minutes ...]-> Level_3_Intro_3
+ [Damn, Uncle Jeb was a busy man!]-> Level_3_Intro_3

== Level_3_Intro_3 ==
[RING RING]
+ [Pick up the phone?] -> Level_3_Tacky_1
+ [They can wait a couple of minutes!] -> Level_3_Intro_3

== Level_3_Tacky_1 ==
~ Show_NPC = true
"0101010010010101- oh sorry was buffering there! Hi Jeb, I need your help with a particularly pesky virus" 
+ [My name's not Jeb, but sure?] ->Level_3_Tacky_2
+ [Yes, this is Jeb, Jeb is I, old Jeb and I'm happy to help] ->Level_3_Tacky_2

== Level_3_Tacky_2==
"Sure Jeb, we get it, you're 103 and quirky like that. See you soon ..." 
+ [Sure thing!]-> Level_3_Tacky_3
+ [Or you could like wait- and she's cut the line on me ...] -> Level_3_Tacky_3

== Level_3_Tacky_3==
~ Show_NPC = false
103??? Perhaps there's a lot for me to learn from Uncle Jeb besides the whole Xorcist thing ... 
+ [Off to the next mission then!]  ->Level_3_Tacky_4
+ [Hmm, I might need to brood a lil' kinda like Constantine] -> Bonus_Brood

==  Level_3_Tacky_4 ==
~ Show_NPC2 = true
"Do you need help? I'm very helpful, just let me delete you from this file and we can get started with a clean slate!"
+ [Woah someone's got a case of bad vibes] -> END
+ [Have you ever considered that maybe you're the problem???] -> END

== Bonus_Brood ==
Hmmm yesssss .... broooding ... MHM ...
+ [Off to the next mission then!]  ->Level_3_Tacky_4
+ [Hmm, I might need to brood a lil' kinda like Constantine] -> Bonus_Brood

