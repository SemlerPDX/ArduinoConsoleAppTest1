# ArduinoConsoleAppTest1

This .NET Framework Console App is an Arduino hardware error demonstration along with the Arduino Sketch here:
https://pastebin.com/C99WT1V4

The issue seems to be with Arduino Micro and not present when running this same sketch on an Uno

Serial write times out eventually, on top of the fact that only the first one or two reads actually retrieve new data.

Anyone with an Arduino Micro, or equivalent clone such as Spark Fun Pro Micro (or any clone of that, KeeYees, OsoYoo, etc.) can test this.


Other issues of note, if the Console App were to attempt to close the port and reopen it, timeouts begin immediately, cannot re-open the port.

Opening the Arduino IDE to the Serial Monitor will show good data, and once closed, can run the Console App again as normal.


I cannot believe no one else has had these issues with Arduino Micro (or clones) and I'm drawing a blank as to how to proceed with testing/troubleshooting.


My discord is here - same name (SemlerPDX): https://discord.gg/MXGxmvT

I'm also in the Arduino Discord, in the Sensors Help channel looking for an expert.
