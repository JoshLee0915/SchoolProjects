Welcome to the lexAnlsScheme

This program reads a specified source file and displays the token stream 
generated from the file. 

The commands to run the program are as follows:

Enter s or start to bring up the dialog to enter a file and start a scan.
Enter l or load to load a new xml file for scanning.
Enter r or reset to reload the default xml.
Enter h or help to redisplay readme.txt.
Enter q or quit to end the program.

####Producing an XML####
To create your own xml follow the following steps.
1. Open Microsoft Excel and create two worksheets named Table 
(your scanning table) and Keywords (your keyword lookup table).

2. Format your scanning table with your states in the first column 
and the characters to scan for in the top row. It should be noted that 
Space, Tab, and NewLine are keywords that are replaced with 
their respective characters when the table is loaded. Also the first 
column that contains your states is for readability only and is 
dropd when the table is loaded. 

3. Fill out your table with the transition states for each character 
in each state. States should be based off a zero based index with the 
start state at zero. Dashes (-) or negative ones (-1) are used 
to specify end states.

4. Save your file as a XML spread sheet 2003.
