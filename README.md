# ArduinoConsoleAppTest1

**===PROBLEM:  Arduino Micro begin to timeout when reading serial data continuously, or on any use of Serial.Close()===**

I found this problem while designing a voice controlled temperature and sensor program (inside the VoiceAttack program) written in C# complied for .NET Framework 4.5. 
My Arduino IDE and libraries are all up to date.  My sketch will send DHT data to my program for text-to-speech replies on voice command request.  I was using Arduino Micro because the Arduino IDE Serial Monitor always showed good data, but not in my program.  Now using Nano without the issues described below.  My solution is currently 'use the right board for the project' due to this problem, outlining it here for others and for future reference.


This is a C# .NET Framework (4.5) Console App written in Visual Studio 2019, using all methods similar enough to my final program, as an Arduino hardware error demonstration along with the Arduino Sketch here:

  (the Hello-World_ArduinoConsoleApp_CompanionSketch requires no attached devices or use of pins:)
  https://pastebin.com/tVVtkGPf

  (or if you want to wire up a DHT11 or DHT22, the exact sketch at time of writing was this:)
  https://pastebin.com/C99WT1V4

_____
**Repro Steps:**

 1. Using an Arduino Micro (or, presumably Leonardo as well, I only have Micro), upload either of the test sketches above
 2. Open the Arduino IDE (set for this board) and the Serial Monitor - verify consistent serial data, no timeouts/issues
 3. Edit the Program.cs and change the PortName on line 19 to the COMPORT of this board
 4. Use this ArduinoConsoleAppTest1 to observe eventual and inevitable timeouts of Serial.Read() attempts
 5. Again, open the Arduino IDE (set for this board) and the Serial Monitor - view consistent serial data, no timeouts/issues
 6. Use this ArduinoConsoleAppTest1 again as desired, observe same problem over and over...
 
   -(showing this is not present on Uno/Nano)-
 1. Next, using an Uno/Nano, upload the sketch listed above (either hello-world or full DHT11/22 tester)
 2. Again, edit the Program.cs and change the PortName on line 19 to the COMPORT of this board
 3. And again, use this ArduinoConsoleAppTest1 (and again, changing the PortName to the COMPORT of this board) to instead view consistent serial data line after line without fail
_____

The issue seems to be with Arduino Micro and not present when running this same sketch on an Uno/Nano; Serial write times out eventually, on top of the Close() issue below.

Anyone with an Arduino Micro, or equivalent clone such as Spark Fun Pro Micro (or any clone of that, KeeYees, OsoYoo, etc.) can test this.


Other issues of note, if the Console App were to attempt to close the port and reopen it, timeouts begin immediately, cannot re-open the port.  Opening the Arduino IDE to the Serial Monitor will again show good data, and once closed, can run the Console App again as normal until timeouts begin once more.


I'm usually not the type to find problems like this, I cannot believe no one else has had these issues with Arduino Micro (or clones) and I'm drawing a blank as to how to proceed with testing/troubleshooting.  I continue to assume this is my own misunderstanding of the differences in the Uno/Nano/Mini class boards and the Micro/Leonardo with the USB CDC Serial hardware.  If there is somewhere I can learn more, or if there is a way to get around these sorts of timeouts, perhaps a better method that must be used with these boards, I would greatly appreciate any tips or suggestions.


My discord is here - same name (SemlerPDX): https://discord.gg/MXGxmvT

I'm also in the Arduino Discord, in the Sensors Help channel looking for an expert.  Thanks for reading!
