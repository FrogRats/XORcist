VAR Show_NPC = false
VAR Show_NPC2 = false

-> Level_3_Outro_1

== Level_3_Outro_1 ==
Dayumn that guy was a little creepy ... a bit familiar though, kind of like the evil long lost cousin of Clippy... 
-> Level_4_Intro_1

== Level_4_Intro_1 ==
[RING RING]
-> Level_4_Intro_2

== Level_4_Intro_2 == 
+ [ Maybe if I don't move, it'll stop ...]-> Level_4_Intro_3
+ [(sigh)]-> Level_4_Intro_3

== Level_4_Intro_3 ==
[RING RING]
+ [Pick up the phone?] -> Level_4_Octogarf_1
+ [They can wait a couple of minutes!] -> Level_4_Intro_3

== Level_4_Octogarf_1 ==
~ Show_NPC = true
"Hey uhm ... so this is embarassing ... we need you to bail us out of this one Jeb ..." 
+ [What yah need?] -> Level_4_Octogarf_2
+ [(The writers really like their pop culture references ... )] -> Level_4_Octogarf_2

== Level_4_Octogarf_2 ==
"... so you know how you told us to never, ever, plug in any random USB into our work gear? Well that definintely didn't happen and we somehow now have a major infestation."
+ [This is just painful ... ] -> Level_4_Octogarf_3
+ [If I keep quiet maybe they'll just give up and hang up] -> Level_4_Octogarf_3

== Level_4_Octogarf_3 ==
"We're gonna take the silence as a yes, see you in a little bit! Also make sure you don't look it in the eyes ... like at all ..."
+ [Damn it- Alright let's go fix this] -> Level_4_Octogarf_4
+ [I should probably get something to eat] -> Bonus_Food

== Level_4_Octogarf_4 ==
~ Show_NPC = false
~ Show_NPC2 = true
"-... --- .-- / -... . ..-. --- .-. . / -- . --..-- / .... ..- -- .- -. -.-.--"
+[.. / -.. --- -. .----. - / ... .--. . .- -.- / -- --- .-. ... . / -.-. --- -.. .] -> Level_4_Octogarf_5
+[.... ..- .... ..--..] -> Level_4_Octogarf_5

== Level_4_Octogarf_5 ==
"-.-- --- ..- .----. .-.. .-.. / .--. .- -.-- / ..-. --- .-. / -.-- --- ..- .-. / ..-. --- --- .-.. .. ... .... -. . ... ... -.-.--" -> END

== Bonus_Food ==
[BRB - FOOD BREAK]
+ [Think I'm good to go now!] -> Level_4_Octogarf_4
+ [I could go for another sandwich] -> Bonus_Food

