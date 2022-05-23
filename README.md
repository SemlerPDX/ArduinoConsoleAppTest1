# ArduinoConsoleAppTest1

==PROBLEM:  Arduino Micro/Leonardo begin to timeout when reading serial data continuously, or on any use of Serial.Close()===

I am designing a voice controlled temperature and sensor program (inside the VoiceAttack program) written in C# complied for .NET Framework 4.5. 
My Arduino IDE and libraries are all up to date.  My sketch will send DHT data to my program for text-to-speech replies on voice command request.

This .NET Framework (4.5) Console App is an Arduino hardware error demonstration along with the Arduino Sketch here:
(the Hello-World_ArduinoConsoleApp_CompanionSketch requires no attached devices or use of pins:)
https://pastebin.com/tVVtkGPf

(or if you want to wire up a DHT11 or DHT22, the exact sketch for my future program was this:)
https://pastebin.com/C99WT1V4

============
Repro Steps:
 -Using an Arduino Micro (or, presumably Leonardo as well, I only have Micro), upload either of the test sketches above
 -Use this ArduinoConsoleAppTest1 to observe eventual and inevitable timeouts of Serial.Read() attempts
 
 -Next, using an Uno/Nano, upload the sketch listed above (either hello-world or full DHT11/22 tester)
 -Again, use this ArduinoConsoleAppTest1 to instead view consistent serial data line after line without fail
============

The issue seems to be with Arduino Micro and not present when running this same sketch on an Uno/Nano

Serial write times out eventually, on top of the fact that only the first one or two reads actually retrieve new data.

Anyone with an Arduino Micro, or equivalent clone such as Spark Fun Pro Micro (or any clone of that, KeeYees, OsoYoo, etc.) can test this.


Other issues of note, if the Console App were to attempt to close the port and reopen it, timeouts begin immediately, cannot re-open the port.

Opening the Arduino IDE to the Serial Monitor will show good data, and once closed, can run the Console App again as normal.


I cannot believe no one else has had these issues with Arduino Micro (or clones) and I'm drawing a blank as to how to proceed with testing/troubleshooting.  I continue to assume this is my own misunderstanding of the differences in the Uno/Nano/Mini class boards and the Micro/Leonardo with the Serial USB CDC.  If there is somewhere I can learn more, or if there is a way to get around these sorts of timeouts, perhaps a better method that must be used with these boards, I would greatly appreciate any tips or suggestions.


My discord is here - same name (SemlerPDX): https://discord.gg/MXGxmvT

I'm also in the Arduino Discord, in the Sensors Help channel looking for an expert.  Thanks for reading!
