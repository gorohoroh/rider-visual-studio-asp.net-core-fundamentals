# ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017

This document compares a developer's experience with an ASP.NET Core 2.0 application in two development environments: JetBrains Rider and Microsoft Visual Studio. For the purposes of providing an all-around, detailed comparison, the document walks through the various coding demos available in Scott Allen's [ASP.NET Core Fundamentals](https://app.pluralsight.com/library/courses/aspdotnet-core-fundamentals/table-of-contents) course (as of November 9, 2017) on Pluralsight.

The steps outlined were taken in Visual Studio 2017 15.7.4 (RTM) and various Rider 2018.2 pre-release builds.

<h2>Creating a new ASP.NET Core Web Application with C# (Empty template)</h2>

<h3>Observations: Rider</h3>
<ol>
    <li>In <em>New Solution</em> wizard, can't select a directory with the updated <em>Open File</em> dialog; have to
        enter path to parent directory manually in <em>Solution directory</em> text box; no recent directories
        available:<br><img src="images/new_solution_select_folder.png" width="600">
    </li>
    <li>Multimonitor support: Rider opened on display 1, <em>New Solution</em> wizard opened on display 2, then <em>Select
        Solution Directory</em> (<em>Open File</em>) opened on display 1 again
    </li>
    <li>Initial IDE layout:
        <ol>
            <li><em>Solution Explorer</em>'s solution node is collapsed (suboptimal),</li>
            <li><em>Scratches and Consoles</em> node is visible (suboptimal, doesn't relate to the created project);
            </li>
            <li>Text editor area is empty, contains generic keymap hints<br><img
                    src="images/solution_created_rider.png" width="600">
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio</h3>
<ol>
    <li><em>Solution Explorer</em>:
        <ol>
            <li>Expanded to file level (good)</li>
            <li>Text editor area contains ASP.NET Code specific overview page with documentation links; <em>Connected
                Services</em> and <em>Publish</em> panes are available for navigation<br><img
                    src="images/solution_created_visual_studio.png" width="600">
            </li>
        </ol>
    </li>
    <li>Multimonitor support: all UI related to creating a project is opened on a single display</li>
</ol>

<h2>Initial run of the application that we've just created</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Accepted <em>Default</em> run configuration settings, built, ran.</p>
<p><em>Run</em> tool window says listening on port 5000, further requests going through the same port.</p>
<p>Browser not automatically opened - however, clicking the link from the <em>Run</em> window works to open
    in default browser.</p>
<p>Stopping is clear: works with <em>Ctrl+C</em> in the <em>Run</em> tool window, as well as with a <em>Stop
    Default</em> command.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All good. Built, ran using the default IIS Express launch profile. Output window showing output from
    ASP.NET Core Web Server, server says listening on port 17570, then requests going through a different
    port (54448) set in generated <em>applicationhost.config</em>, default browser (Chrome) automatically
    opened with the correct URL.</p>
<p>Links from the <em>Output</em> window can be <em>Ctrl</em>+clicked, which is a tiny bit worse than what
    Rider does.</p>
<p>Stopping is not clear: can't <em>Ctrl+C</em> in the <em>Output</em> window, and no Stop command is
    available in the <em>Debug</em> menu. The application can be either rerun from Visual Studio, or stopped
    using the separate IIS Express UI:<br><img width="600" src="images/iis_express_ui.png">
</p>

<h3>Notes, issues, commits</h3>
<p>I assume that the differences in start/stop experience are due to Visual Studio <a
        href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/aspnet-core-module?view=aspnetcore-2.1">using
    IIS Express as a proxy</a> to Kestrel and Rider using Kestrel
    directly.
</p>