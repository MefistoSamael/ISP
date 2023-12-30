<h2>Lab1<h2/>
a. Implement a Windows calculator.
b. Use ONE handler (one method in code-behind) for the "click" event of all digital buttons.
c. Add a function according to the individual assignment.
d. The page should be selected in the Flyout navigation menu in Shell.

<h2>Lab2<h2/>
In the project from Laboratory Work #1, add a page containing a Label, ProgressBar, and two buttons.
On clicking the Start button, asynchronously (await, async Task), calculate the integral of the function y=sin(x) on the interval from 0 to 1 (use the rectangle method). Use a step of 0.00000001 for iteration. To increase the computation time, introduce a delay in the form of a loop of 100,000 formal calculations on each iteration (e.g., multiplying two numbers). Adjust the values so that the calculation takes about a second.
The ProgressBar should display the progress of the calculation. Also, the progress should be displayed as a percentage (see the figure).
The Cancel button is intended to cancel the calculation (use CancellationToken).
The Label at the top of the screen (in the figure, "Welcome to .NET MAUI!") should change to the following messages:
- "Calculating" when the integration calculation is in progress (by clicking the Start button);
- the result of the integration calculation upon completion;
- "Task canceled" if the Cancel button was pressed during the calculation.

<h2>Lab3<h2/>
Develop a page where, upon selecting a group, a list of object names in that group is displayed.

<h2>Lab4<h2/>
Add a page to the project - "Currency Converter."
The converter should:
1. Display the official exchange rate of the Belarusian ruble set by the National Bank of the Republic of Belarus on the selected date for the following currencies:
* Russian Ruble
* Euro
* US Dollar
* Swiss Franc
* Chinese Yuan
* British Pound
2. Choose the currency for conversion.
3. Allow converting the amount in Belarusian rubles to the selected foreign currency (see point 2) and vice versa.
