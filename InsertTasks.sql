insert into Task(TaskName, TaskDescription, TaskSolution, TaskTestingParameters) 
		values 
			('Find sum of provided params', 'Find sum of provided params', 'return a + b;', 'int a = 1, int b = 2'),
			('Find sum 1 and 3', 'Find sum 1 and 3', 'return 1 + 3;', ''),
			('Find sum 5 and 3', 'Find sum 5 and 3', 'return 5 + 3;', ''),
			('Sum and triple sum','Write a C# Sharp program to compute the sum of the two given integer values. If the two values are the same, then return triple their sum.', 'return x == y ? (x + y)*3 : x + y;', 'int a = 3, int b = 1)'),
			('Task with strings','Write a C# Sharp program to create  a new string with the last char added at the front and back of a given string of length 1 or more.','var s = str.Substring(str.Length-1);
            return s + str + s;','string str = "Green"')