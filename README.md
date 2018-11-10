# ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017

This document compares a developer's experience with an ASP.NET Core 2.0 application in two development environments: JetBrains Rider and Microsoft Visual Studio. For the purposes of providing an all-around, detailed comparison, the document walks through the various coding demos available in Scott Allen's [ASP.NET Core Fundamentals](https://app.pluralsight.com/library/courses/aspdotnet-core-fundamentals/table-of-contents) course (as of November 9, 2017) on Pluralsight.

The steps outlined were taken in Visual Studio 2017 15.7.4 (RTM) and various Rider 2018.2 pre-release builds.

<h2>Creating a new ASP.NET Core Web Application with C# (Empty template)</h2>

<h3>Observations: Rider :yellow_heart:</h3>
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

<h3>Observations: Visual Studio :green_heart:</h3>
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

<h2>Opening and editing project file</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Project file can be opened in text editor via <em>F4</em> or via right-click &gt; <em>Edit &gt; Edit
    ....csproj</em>.</p>
<p>No <em>Quick Info</em> available on elements.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Project file can be opened in text editor via right-click &gt; <em>Edit project file</em>.</p>
<p><em>Quick Info</em> tooltip is available on hover for valid <em>.csproj</em> elements:<br/>
    <img width="600" src="images/vs_csproj_quick_info.png">
</p>

<h2>Creating a configuration file (appsettings.json)</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Right-click project node &gt; <em>Add &gt; JSON file</em>. Just a generic JSON file template based on
    WebStorm. No predefined name, empty content.</p>

<h3>Observations: Visual Studio  :green_heart:</h3>
<p>Right-click project node &gt; <em>Add &gt; New Item </em>(or <em>Ctrl+Shift+A</em>)<em> &gt; ASP.NET Core
    &gt; ASP.NET Core Configuration File</em> (renamed to <em><u>App Settings File</u></em> in later VS
    versions). Provides a predefined name (<em>appsettings.json</em>), default file template contains a
    <code>ConnectionStrings: DefaultConnection</code> setting.<br>
    <img width="600" src="images/vs_appsettings_json.png">
</p>

<h2>Modifying Startup.cs to use a value from appsettings.json</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Good editing experience in JSON and C#. Import popup more useful than explicitly calling <em>Ctrl+.</em>
    in Visual Studio for importing a reference for <code>IConfiguration</code>.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Good editing experience in JSON and C#. Complete Statement doesn't work in JSON though, and importing a
    reference for <code>IConfiguration</code> is less obvious/comfortable than in Rider.</p>

<h2>Creating and injecting a custom Greeter service instead of hardcoded settings value</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All fine. Regular C# coding that involves Create from Usage and implementing interface members in a
    derived class.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All fine. Visual Studio handles Create from Usage and implementing interface members in a derived class,
    although not exactly as polished as Rider - good enough though:</p>
<ol>
    <li>Visual Studio does allow implementing <code>IGreeter</code> from usage when the <code>Greeter</code>
        class has been declared; however, Rider does have the advantage of providing the <em>Create derived
            type</em> context action upon the <code>IGreeter</code> declaration.
    </li>
    <li>VS create from usage isn't quite on par right now: given the undeclared <code>IGreeter</code>
        interface in method parameteres and the below line that uses an undeclared method,
        <ol>
            <li>The created symbol doesn't get focus: both when it's created in a separate file and when
                it's created in the same file</li>
            <li>Roslyn doesn't infer that the generated method should return a string, not an object
            </li>
        </ol>
    </li>
</ol>

<h3>Notes, issues, commits</h3>
<a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/972408e215db8f217a500e7c7ee4ecfe8353eecf">Commit link</a>