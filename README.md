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

<h3>Notes, commits</h3>
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

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/972408e215db8f217a500e7c7ee4ecfe8353eecf">Commit link</a></p>

<h2>Configuring middleware: using IApplicationBuilder</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Good enough. Regular C# editing with certain issues both in Rider and Visual Studio. For example, Rider's
    completion doesn't expect an identifier after the <code>async</code> keyword, so it starts to suggest
    weird classes, and this is where completion on space hurts: I wanted to type an unresolved symbol,
    <code>context</code>, but completion triggered on <em>Space</em> and inserted the unwanted
    <code>ContextBoundObject</code>
    class. Similar bad completion on unresolved symbol just below: wanted to use undeclared
    <code>logger</code> to add it as parameter later, but got <code>Logger&lt;&gt;</code> completed instead.
    See commit for details and context.</p>
<p>Additionally, Rider displays annoying Parameter Info tooltip in random spots inside the delegate:<br/><img
        width="600" src="images/rider_annoying_tooltip_with_delegates.png">
</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Good enough. Regular C# editing with certain issues both in Rider and Visual Studio. For example, VS
    completion breaks down after the <code>await</code> keyword - no longer suggests anything. Workaround:
    type a sync statement first, then add the <code>await</code> keyword. Rider handles this just fine. See
    commit for details and context.</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/ad558809904c44af3a7f2aa3242958896c805c30">Commit link</a></p>

<h2>Configuring middleware: showing exception details and configuring environment-specific middleware</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Good enough in terms of C# editing, although the "Use string interpolation" CA wasn't available when I
    needed it:</p>
<p><img width="600" src="images/rider_no_string_interpolation_ca.png">
</p>
<p>Rider doesn't pick environment or any other settings from <em>launchSettings.json</em> because it doesn't
    support launch settings: neither are they created with the ASP.NET Core template nor are they reflected
    in run configurations. Instead, environment variable settings in the default run configuration must be
    edited to switch to a different environment:<br><br><img width="600" src="images/rider_environment_variables_via_run_configuration.png">
</p>
<p>Creating <em>appsettings.Development.json</em>:</p>
<ol>
    <li>Creating via copy-paste of <em>appsettings.json</em> works a little better than in Visual Studio
        because Rider suggest entering a name for the copy before actually creating it, and then suggests
        adding the new file to Git.
    </li>
    <li>However, Rider doesn't by default nest <em>appsettings.Development.json</em> under <em>appsettings.json</em>
        as Visual Studio does. Had to click <em>File Nesting Settings</em> in the toolbar and manually enter
        a nesting rule: <em>parent: .json, child: .Development.json</em>.<br><img width="600"
                src="images/appsettings_nesting.png">
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Good enough in terms of C# editing.</p>
<p>Launch settings are natively supported, as opposed to Rider.</p>
<p><em>appsettings.Development.json</em> was automatically nested under <em>appsettings.json</em> and didn't
    require any manual configuration.</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/032855d2ac63c7bdca103045f5da2b01cda12405">Commit
    link</a></p>
<p>Neither in Visual Studio nor in Rider was I able to replicate Scott's exercise with displaying a Greeting
    value from <em>appsettings.Development.json</em> for some reason - probably a configuration mishap on my
    side.</p>

<h2>Configuring middleware: serving static files</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All good. Involves regular C# editing + creating an HTML file.</p>
<p>Live template for HTML file in Rider is slightly better as it places a hotspot at the value of the <code>&lt;title&gt;</code>
    tag, and then Rider suggests adding the new file to Git.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All good. Involves regular C# editing + creating an HTML file.</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/94d61f8fd0dc0354b8d67350d5e3fed978edd977">Commit
        link</a></p>
<p>
    Along with creating an HTML file, Visual Studio removes a section that includes the <em>wwwroot</em> folder from the
    .<em>csproj</em> file. Rider doesn't do that. Unsure if this has any side effects so far.
</p>

<h2>Configuring middleware for ASP.NET MVC and adding a simple Home controller</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Viewing NuGet dependencies in Solution Explorer works fine. "Manage NuGet Packages" command is available
    in contextual menu for more nodes of the Dependencies tree than in Visual Studio, which is fine.</p>
<p>Adding a directory is easier in Rider as it can be done via <code>Alt+Insert</code>, along with adding
    new files.</p>
<p>Rider's lowerCamelCase and CamelCase completion matching is inferior to Visual Studio in simple cases
    like the below. Visual Studio suggest the expected <code>UseStaticFiles()</code> method matching <code>usf</code>;
    Rider suggests <code>UseDefaultFiles()</code> instead, both when matching with <code>usf</code> and
    <code>USF</code> (!!!!):<br/>
    <img width="600" src="images/camelcase_completion_vs.png">
    <br/>
    vs<br/>
    <img width="600" src="images/camelcase_completion_rider.png">
</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Viewing NuGet dependencies in Solution Explorer works fine.</p>
<p>Adding a directory in Visual Studio is harder: for some reason, Visual Studio's "New folder" is only available as a
    separate contextual command, and not as an item in <em>Add New Item</em> (<code>Ctrl+Shift+A</code>).
</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/f6379b24491e9a60284adf7f3c242626dcc0b24a">Commit
        link</a></p>
        
<h2>Setting up conventional routing</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All fine with C# editing and adding a new controller</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All fine with C# editing and adding a new controller</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/3f4f74f725d9910d69567b156bb6226eb4adcab2">Commit link</a></p>

<h2>Setting up attribute routes</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Editing C# attributes works fine; however, import completion for the Route attribute is severely hanging:<br/>
    <img  width="600"
         src="images/rider_attribute_import_completion.png">
</p>
<h3>Observations: Visual Studio :green_heart:</h3>
<p>C# editing around attributes works as expected.</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/2373c1b43b144f22205b6a02f32ca42ce8b0db34">Commit link</a></p>

<h2>Action results: deriving from the <code>Controller</code> base class, modifying an
    action to return <code>IActionResult</code>, creating a <code>Restaurant</code> model, instantiating and
    returning the model instance from the controller
</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All good in terms of editing C# in the controller and creating a new directory for models and a new model
    in it (tried using <em>Move</em> CA and refactoring)</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All good in terms of editing C# and creating a new directory and a new model (except that creating a new
    directory is a separate action - see one of the above Visual Studio notes)</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/f657b1f97da8ffbee2cd2dea2f3244b6c09c1117">Commit link</a></p>

<h2>Creating and rendering a view</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Rider is superior in this scenario: creating a view from usage (<code>return View(model);</code>) in the
    controller:</p>
<ol>
    <li>Creates the entire folder structure for views along with the actual view;</li>
    <li>The view is auto-typed with the model (if the model is provided) via a <code>@model</code>
        directive,
    </li>
    <li><code>@using</code> directives are automatically inserted, and a hotspot is placed at the bare
        HTML's <code>&lt;title&gt;</code> tag value.
    </li>
</ol>
<p><img width="600" src="images/rider_create_view_from_usage.png">
</p>
<p>One small hiccup is that when importing the model, FQN is used both in the model and in the using
    statement whereas it's only required in the using statement.</p>
<p>If a Razor view is created using a file template, the resulting view is more complete as well.</p>
<p>When manually typing a model (<code>@model Restaurant</code>), Rider auto-imports the model namespace;
    Visual Studio doesn't do this.</p>
<p>Rider makes Extend/Shrink Selection available in Razor views whereas Visual Studio doesn't.</p>
<p>Other than that, when using the imported model in the Razor markup, it's quite annoying that completion
    suggests <code>@model</code> when model is typed, even though the lower-case <code>@model</code> is only
    applicable as the import statement, and <code>@Model</code> should be provided instead.</p>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio is lagging behind severely in this scenario:</p>
<ol>
    <li>You can't create a view from usage, at all.</li>
    <li>This means if you're creating the default initial folder structure for models, you have to create a
        directory twice (separate action), and then use <em>Add New Item</em> to create a view.
    </li>
    <li>In the view, Scott right away removes the default content and uses the html template to roll out a
        barebones HTML structure (this template isn't available in Rider but it's not needed there because
        Rider's default template for a Razor view is way better and already contains an HTML skeleton.
    </li>
</ol>
<p>When manually typing a model (<code>@model Restaurant</code>), Visual Studio doesn't suggest importing the model
    namespace - you need to manually type in an FQN.
</p>
<p>Visual Studio doesn't provide <em>Expand/Contract Selection</em> commands in Razor views.
</p>
<p>Visual Studio's completion only suggests the uppercase <code>@Model</code> property outside of the imports; however,
    it doesn't suggest anything when you type the lowercase <code>@model</code>, which means Rider's problem with
    suggested casing isn't as serious as it looks, because there's no typing habit for Rider completion to break when
    dealing with Visual Studio typing patterns.
</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/21a5fc3cdd024c69531d5805cd358d4e3b979801">Commit
        link</a></p>
        
<h2>Populating with data: creating a <em>Services</em> directory and moving
    <code>IGreeter</code> service there
</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Creating a new directory, again, is a bit easier. Rider modifies .csproj with a new folder include but
    Visual Studio doesn't do that: again, unclear differences in project model handling although it looks
    like Rider uses Visual Studio 2017's MSBuild distribution.</p>
<p>Moving <em>IGreeter.cs</em> to the new directory can be done with drag-n-drop, in which case VCS
    integration interprets the operation as a move (whereas the Visual Studio's d-n-d is seen as a file
    deletion + file addition). However, moving with drag-and-drop in Rider seems to introduce differences in
    line endings!</p>
<p>The better way to move <em>IGreeter.cs</em> to the new directory is certainly via Refactor This &gt; Move
    to Folder on the file node in Solution Explorer. Invoking the refactoring with default settings (that
    include fixing namespaces) just works. Good job:<br/>
    <img width="600" src="images/rider_move_to_folder.png">
</p>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Moving <em>IGreeter.cs</em> to the new <em>Services</em> directory by drag-n-drop in Solution Explorer.
    Requires updating the namespace in <code>IGreeter</code>, then compiling and going through several <em>CS0246</em>
    build errors to add a missing using directive in <em>Startup.cs</em>.</p>
<p>Subpar manual experience as Visual Studio doesn't have a <em>Move to Folder</em> refactoring (in fact, no
    <em>Move</em> refactorings at all, and no refactorings available on Solution Explorer nodes.)</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/d80c2e6cd303271aa9cda9b6c75439f156e82014">Commit
        link</a></p>

<h2>Creating new services: <code>IRestaurantData</code>,
    <code>InMemoryRestaurantData</code>, registering one of them in <em>Startup.cs</em>, modifying the Home
    controller to receive restaurant data from an <code>IRestaurantData</code> service, updating the view to
    accept an enumerable model and iterate through the collection of restaurants
</h2>

<h3>Observations: Rider :green_heart:</h3>
<ol>
    <li>Creating <code>IRestaurantData</code> via <em>Alt+Ins</em>: good, and again, Rider suggests to add
        the new file to Git right away.
    </li>
    <li>Declaring an interface member: <em>Complete Statement</em> at <code>GetAll{caret}</code> generates
        both the parentheses and the semicolon, Visual Studio doesn't do this.
    </li>
    <li>Creating <code>InMemoryRestaurantData</code> class: can be done with <em>Alt+Ins</em> but can also
        be done easier with a context action on <code>IRestaurantData</code> declaration to create a derived
        type:<br><img width="600" src="images/rider_create_derived_type.png"><br>
        Then, there's a quick-fix to implement the interface, and a context action to move to a separate file.
    </li>
    <li>Writing code in <code>InMemoryRestaurantData</code>: good. Notes:
        <ol>
            <li>Quick-fix <em>Initialize field from constructor</em> is available after declaring the
                <code>_restaurants</code> field:<br>
                <img width="600" src="images/rider_initialize_field_from_constructor.png"><br>However,
                the created constructor takes a list of restaurants as a parameter; what we need instead is
                a parameterless constructor with a field inside that is initialized with a new list. No
                context action or refactoring to convert parameter to field initialization, and the <em>Change
                    Signature</em> refactoring doesn't do that, too. No big deal to do this by hand though.
            </li>
            <li>Rider's code completion after the <code>new</code> keyword in collection initializer
                results in <code>new Restaurant()</code>, but the parentheses become redundant once braces
                are added for initializing properties. A typing assistant that removes redundant parentheses
                wouldn't hurt here.
            </li>
        </ol>
    </li>
    <li>Modifying the Home controller: great! Notes:
        <ol>
            <li>This time, after declaring a field and calling the <em>Initialize field from
                constructor</em> quick-fix, it does exactly what we want: declares a constructor with a
                <code>IRestaurantData</code> parameter. Nice!
            </li>
            <li>After modifying the parameter returned in <code>View()</code> to a collection of
                restaurants, Rider shows an error and suggests to modify the type of the view. Super
                nice!<br><img width="600" src="images/rider_change_view_model_type.png">
            </li>
        </ol>
    </li>
    <li>Modifying the Home view. Works, however:
        <ol>
            <li>No live template for an HTML table in Razor views. As a side note, there is one in HTML
                files handled by WebStorm, but it only generates a <code>&lt;table&gt;</code> tag pair, with
                no rows or cells inside - Visual Studio does better here.
            </li>
            <li>No <code>foreach</code> live template in Razor, only keyword completion - same as in Visual
                Studio. Also, no way to surround markup with braces.
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio does it all fine actually; yellow here just means that Rider is significantly better during
    this coding segment.</p>
<ol>
    <li>Creating <code>IRestaurantData</code> via <em>Ctrl+Shift+A</em>: fine.</li>
    <li>Creating the derived <code>InMemoryRestaurantData</code> class: also has to be done with <em>Ctrl+Shift+A</em>
        because there's no action to create a derived type.
    </li>
    <li>Writing code in <code>InMemoryRestaurantData</code>: all fine, with a few notes:
        <ol>
            <li>When modifying the class declaration to implement <code>IRestaurant</code>, Visual Studio
                provides <em>Implement interface</em> and <em>Implement interface explicitly</em> quick
                actions. Nice.
            </li>
            <li>Scott creates a <code>InMemoryRestaurantData()</code> constructor with the <code>ctor</code>
                code snippet - nice, but that's the only option with VS as there's no context action on a
                field to initialize the field from constructor.
            </li>
        </ol>
    </li>
    <li>Modifying the Home controller: good. Notes:
        <ol>
            <li>Visual Studio doesn't have import items in completion, which means that when referencing an
                unimported type, you have to make sure to spell and capitalize it correctly, and then use a
                quick action to add an import. In Rider, import items are available in completion, which
                allows using camelHumps and abbreviations without being precise with naming, and
                additionally, accepting an import symbol suggestion adds the necessary using statement
                without the need to explicitly invoke a quick action.
            </li>
            <li>Visual Studio provides a set of quick actions to generate <code>_restaurantData</code> (as a
                full or read-only field, full or read-only property, local variable); as well as explicit
                actions to change <code>_restaurantData</code> to <code>IRestaurantData</code> or
                <code>restaurantData</code>:<br><img width="600" src="images/vs_generate_from_usage.png">
            </li>
        </ol>
    </li>
    <li>Modifying the Home view: good. Notes:
        <ol>
            <li>There's a <em>table</em> code snippet to generate an HTML table in Razor markup, nice.</li>
            <li>However, there's no <em>foreach</em> code snippet, just keyword completion.</li>
        </ol>
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/47fe289c741a5e54340cdec78fdbc9918f7bdcdc">Commit
        link</a></p>

<h2>Creating and using a view model for the Index view</h2>

<h3>Observations: Rider :green_heart:</h3>
<ol>
    <li>Creating a directory and file for view model: good (both can be created from <em>Alt+Ins</em>, Git
        add suggestion.) Again, import items in completion rock!
    </li>
    <li>Modifying the controller: great. Initialize field from constructor rocks after declaring the
        <code>_greeter</code>
        field! <em>Use object initializer</em> is available both on constructor call and on further variable
        usages. The <em>Change view model type</em> quick-fix rocks again!
    </li>
    <li>Modifying the view: considerably better than Visual Studio (because the model type has already been
        changed for us, and because <code>Model</code> is resolved quicker, with valid completion
        suggestions available instantly.
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Again, Visual Studio does a good job, it's just Rider that does it better.</p>
<ol>
    <li>Creating a directory and a file for the first view model: all fine.</li>
    <li>Modifying the controller: fine. <em>Initialize field from constructor</em> would be handy but it's not there. As
        a side note, Visual Studio now provides a quick action to use object initializer - the action is available from
        the constructor call only though, not from variable usages:<br/>
        <img width="600" src="images/vs_object_initialization.png">
    </li>
    <li>Modifying the view: decent. Had to change model type by hand, after which it took Visual Studio ~30 seconds to
        re-resolve the <code>Model</code> in <code>foreach</code>, figure out it's now a <code>HomeIndexViewModel</code>
        and finally start suggesting view model properties in code completion.
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/fde46ac4973fc1a76ba70bcc3b2f6b1b0c3922c4">Commit
        link</a></p>

<h2>Creating a new Home controller action <code>Details(int id)</code>, updating services
    with a new <code>Get(int id)</code> method to return details for a particular restaurant, creating a simple
    <em>Details</em> view, updating the <em>Index</em> view to use tag helpers and creating a required <em>_ViewImports.cshtml</em>
    along the way.
</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Mixed result: Rider shines with a few great features in this segment but there's a bunch of bugs as
    well.</p>
<ol>
    <li>Creating a <code>Details(int id)</code> action in the Home controller: OK.
        <ol>
            <li>Similar code completion issues in Rider. Creating a method from usage works and also doesn't insert an
                implementation stub in the derived class; however, provides a placeholder to change the default return
                type from <code>object</code> to something else (<code>Restaurant</code>) in our case.
            </li>
            <li>A null check on model is easier to introduce with the <em>Check variable for null</em>
                context action that is conveniently available at the end of the statement; a quick path to
                null check pattern settings is provided, too - nice!<br>
                <img width="600" src="images/rider_check_variable_for_null.png">
            </li>
            <li>When returning <code>RedirectToAction("Index")</code>, Rider provides code completion for actions in
                the string literal that is passed over as parameter as well as navigation to action, nice!<br>
                <img width="600" src="images/rider_view_completion_in_string_literals.png"><br>
                Using <code>nameof(Index)</code> is a bit problematic due to a ReSharper bug (RSRP-469876) but if it's
                just typed in without completion, Rider actually continues to provide navigation to the view!<br>
                <img src="images/rider_navigation_to_action_with_nameof.png">
            </li>
            <li>When returning a View(model), Rider detects that the referenced view is missing and suggests to create
                it:<br>
                <img width="600" src="images/rider_create_razor_views.png">
            </li>
        </ol>
    </li>
    <li>Updating services with a new <code>Get(int id)</code> method: fine. There actually is a (poorly discoverable)
        context action to implement the new interface method in derived classes:<br>
        <img width="600" src="images/rider_implement_in_derived_classes.png"><br>
        Good to know it's here but I'd expect a quick-fix instead. All in all, fine editing in both services.
    </li>
    <li>
        Creating the <em>Details</em> view: good, with a few quirks!
        <ol>
            <li>
                Created with a quick-fix from controller (see above) - nice!
            </li>
            <li>
                However, model completion suggests an unqualified <code>Restaurant</code> type, which then triggers an
                import action, and all that ends up with FQNs in both <code>@using</code> and <code>@model</code>
                directives - which, in turn, requires removing FQN from the <code>@model</code> directive with a
                quick-fix. Also, the file template's active hotspot in the <code>&lt;title&gt;</code> tag prevents from
                calling <em>Alt+Enter</em> on the <em>@model</em> directive - you need to fill the hotspot first of all.
            </li>
            <li><code>ModelExpressionProvider</code> annoys as the first completion suggestion for both
                <code>@mod</code> and <code>@Mod</code> - should be <code>@Model</code> instead!
            </li>
            <li>Trying to write a tag helper but there's no completion for asp-* attributes and their values. This is
                because there's no <em>_ViewImports.cshtml</em>, and Rider doesn't provide a quick-fix to create one!
            </li>
            <li>However, after creating <em>_ViewImports.cshtml</em> (see next step), Rider starts to provide completion
                for both tag helper attributes (<code>asp-action</code> and such) and their values, nice!<br>
                <img width="600" src="images/rider_completion_tag_helper_values.png">
            </li>
        </ol>
    </li>
    <li>Creating <em>_ViewImports.cshtml</em>: with hiccups as there's no cshtml items in <em>Alt+Ins</em> on the <em>Views</em>
        folder (only on nested folders). Workaround: use a generic File file template. After creating <em>_ViewImports.cshtml</em>,
        there are no completion suggestions for assembly name in Rider, just like in Visual Studio :( - completion for
        the <code>@addTagHelper</code> directive is available though.
    </li>
    <li>Modifying the <em>Index</em> view to render links to restaurant details using 3 different kinds of syntax: fine,
        with a few hiccups:
        <ol>
            <li>When entering the regular anchor with relative paths, Rider complains it doesn't recognize the relative
                path, suggests to set path mapping, then nothing happens but the inspection is gone. Trying to edit path
                mappings fails silently:<br/>
                <img width="600" src="images/rider_path_mapping.png">
            </li>
            <li>Action link syntax: again, action resolve in string parameter; however, completion can be
                improved:<br>
                <img width="600" src="images/rider_completion_actionlink.png">
            </li>
            <li>Tag helper syntax: good! Rider even suggests asp-route-id that is derived from the Details action
                signature - something that Visual Studio doesn't do:<br>
                <img width="600" src="images/rider_completion_asp_route_id.png">
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio does the job but overall in a lot less intelligent way than Rider.</p>
<ol>
    <li>Creating a <code>Details(int id)</code> action in the Home controller: decent.
        <ol>
            <li>Some code completion issues in Visual Studio when using a new method <code>Get(id)</code>
                before declaring it; creating the method in the interface from usage works (doesn't insert
                an implementation stub in the derived <code>InMemoryRestaurantData</code> though).
            </li>
            <li>Returning <code>RedirectToAction("Index")</code> works but Visual Studio doesn't provide
                code completion for actions in the string literal, and Scott prefers to use <code>nameof(Index)</code>
                instead; when returning a <code>View(model)</code>.
            </li>
            <li>Visual Studio doesn't see that the view doesn't exist and doesn't suggest to create one.
            </li>
        </ol>
    </li>
    <li>Updating services with a new <code>Get(int id)</code> method: fine. When going to the derived <code>InMemoryRestaurantData</code>,
        Visual Studio does provide a quick action to implement the new interface method.
    </li>
    <li>Creating the <em>Details</em> view: OK. No completion for controller and action names in tag helpers
        though.
    </li>
    <li>Creating <em>_ViewImports.cshtml</em>: OK, using a specialized item via <em>Ctrl+Shift+A</em>.
        However, Visual Studio provides no completion for the assembly name refrenced from <em>_ViewImports.cshtml</em>.
    </li>
    <li>Modifying the <em>Index</em> view to render links to restaurant details using 3 different kinds of
        syntax: <code>&lt;a href&gt;</code>, <code>@Html.ActionLink</code> and a tag helper. Visual Studio
        provides completion for tag helper attributes but, again, there's no code completion for controller
        and view names in string literals - only for C# symbols after <code>@</code>.
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/ddc5a0ebabab97464050d15219bfe3c4ea143615">Commit
        link</a></p>
        
<h2>Adding a form to create restaurants</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Even though there are code analysis and code completion bugs when editing a view, the overall experience
    in this scenario is much richer than in Visual Studio.</p>
<ol>
    <li>Link from <em>Index.cshtml</em> to a new action: great! Rider sees that there's no
        <code>Create()</code> action yet, and provides a quick-fix to create one:<br>
        <img width="600" src="images/rider_create_action_from_usage.png">
    </li>
    <li>New <code>Create()</code> action in Home Controller auto-created with the quick-fix. Now, adding a
        reference to a view that doesn't exist yet - Rider detects this, suggests to create one, and it's
        there now (and added to Git). Great!
    </li>
    <li>Creating a new <code>CuisineType</code> enum in Models: can use the <em>enum</em> file template right away.
    </li>
    <li>
        Adding a <code>CuisineType</code> property to the <code>Restaurant</code> model: OK.
    </li>
    <li>Writing code in the <em>Create.cshtml</em> view (that was auto-created for us at step 2 above):
        <ol>
            <li>No issue with model import as we referenced the model when the view was created, via a hotspot.</li>
            <li>No snippets for <em>form</em>, <em>select</em>, <em>input</em> are available.</li>
            <li>Completion list for the <em>asp-for</em> attribute can be improved:<br>
                <img width="600" src="images/rider_completion_asp-for_bug.png"><br>
                However, completion for model fields in <em>asp-for</em> value is available!
            </li>
            <li>Completion for <code>CuisineType</code> is available:<br>
                <img width="600" src="images/rider_view_completion_unimported_type.png"><br>
                However! When using the <code>@</code>
                prefix ahead of the expression in the asp-items value (which compiles fine), Rider shows a bogus <em>Cannot
                    choose method from method group</em> error and fails to resolve the type parameter. When the
                <code>@</code> prefix is not used, Rider doesn't complain, and the application still compiles and runs
                (RSRP-469518)
            </li>
            <li>Completion for <em>input</em> types is available:<br>
                <img width="600" src="images/rider_view_input_type_completion.png">
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio does the job but Rider provides a lot more automation in this scenario.</p>
<ol>
    <li>Link from <em>Index.cshtml</em> to a new <code>Create()</code> action: Visual Studio doesn't detect
        that there's no action yet. Have to create by hand in the next step.
    </li>
    <li>Creating a new <code>Create()</code> action in the Home controller. When returning
        <code>View()</code>, Visual Studio doesn't see there's no view yet.
    </li>
    <li>Creating a new <code>CuisineType</code> enum in Models: adding a new class, then changing it to
        <code>enum</code> and populating. OK.
    </li>
    <li>Adding a <code>CuisineType</code> property to the <code>Restaurant</code> model with the
        <em>prop</em> snippet: OK.
    </li>
    <li>Creating a <em>Create.cshtml</em> view manually. Notes:
        <ol>
            <li>There are no import suggestions for non-FQN types when declaring a model, have to type in
                the FQN by hand, although code completion does help with FQN
            </li>
            <li>Snippets are available for <em>form</em>, <em>select</em>, and <em>input</em>, nice!</li>
            <li>Completion of model properties in tag helpers such as <em>asp-for</em>, <em>asp-items</em> -
                nice!<br>
                <img width="600" src="images/vs_cshtml_input_asp-for_completion.png">
            </li>
            <li>When referencing the <code>CuisineType</code> enum, Visual Studio doesn't provide an import
                suggestion, have to go up and type a <code>@using</code> by hand.
            </li>
        </ol>
    </li>
</ol>

<h3>Notes, commits</h3>
<p>Commit links:</p>
<ul>
    <li><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/317f2e8633e4c4936cbed1ca0bc4f871c9ea3142">One</a></li>
    <li><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/e1eef7de9df1b945a2555184e845b74e101f62b3">Two</a></li>
</ul>

<h2>Accepting form input: adding a restaurant edit model, modifying services,
    the Details view, and creating a new Home controller action
</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Rider's workflow is better automated but there are annoyances along the way. They were reported earlier,
    so let's say this is a tie with Visual Studio.</p>
<ol>
    <li>
        Creating a <code>Create()</code> action overload in the <em>Home</em> controller: OK. Creating <code>RestaurantEditModel</code>
        from usage. Created in the <em>Home</em> controller, then moved to a separate file with a context action (still
        under <em>Controllers</em> though), then <em>Refactor This &gt; Move to Folder</em> to move the new file to <em>ViewModels</em>.
        Quite a complicated chain of actions but works, and <em>Move to Folder</em> does auto-adjust the namespace by
        default.
    </li>
    <li>Creating properties in <code>RestaurantEditModel</code> - good.</li>
    <li>Using <em>Implement in derived classes</em> CA in <code>IRestaurantData</code> to create an implementation stub
        in <code>InMemoryRestaurantData</code> and navigate there - great! Writing implementation logic - good.
    </li>
    <li>Adding route constraint attributes to the two <code>Create()</code> actions: hanging completion strikes again.
    </li>
    <li>Can navigate from the <em>Home</em> controller to <em>Details.cshtml</em> to modify the view. Modifying the
        view: OK, although, again, completion for <code>@Model</code> is annoying.
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Visual Studio does the job with less automation but Rider's bugs set back its functional advantages.
    Tie in this scenario.</p>
<ol>
    <li>Creating a <code>Create()</code> action overload in the <em>Home</em> controller to convert input
        data into a new restaurant item.
    </li>
    <li>Creating a <code>RestaurantEditModel</code> input model in <em>ViewModels</em> via <em>Add New
        Item</em> - although this in fact could be created from usage in the <em>Home</em> controller, in
        which case the file would have been created in the <em>Controllers</em> folder and then should have
        been moved to <em>ViewModels</em> (and we know Visual Studio can't modify namespaces on
        drag-and-drop).
    </li>
    <li>Modifying the new <code>Create()</code> action in the <em>Home</em> controller to receive 
        a <code>RestaurantEditModel</code>, all good.
    </li>
    <li>Adding route constraints (attributes) to the two <code>Create()</code> actions.</li>
    <li>Processing input model in the input <code>Create()</code> action. Using an <code>Add()</code> method
        from <code>IRestaurantData</code> that is not declared yet, and generating it from usage.
    </li>
    <li>Implementing the <code>Add()</code> method in <code>InMemoryRestaurantData</code>: <em>Go to
        Implementation</em> from <code>IRestaurantData</code> interface declaration (because there's no <em>Go
        to Implementation</em> on specific members), and using the <em>Implement interface</em> quick action
        to create a stub. Writing implementation code.
    </li>
    <li>Modifying the <em>Details.cshtml</em> view to show more data on the restaurant entry that we've just
        created.
    </li>
</ol>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/e005da1a5e37f28a268f9af8f29d210425e0659e">Commit link</a></p>

<h2>Adding a redirect to action to prevent duplicate POST requests</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Just a one-line change to the return of the POST-specific <code>Create()</code> action: OK. Used string
    literal for view name instead of the <code>nameof</code> approach in Visual Studio because of the
    <code>nameof</code> completion bug referenced somewhere above.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Just a one-line change to the return of the POST-specific <code>Create()</code> action: OK. Used <code>nameof</code>
    for better completion because Visual Studio doesn't suggest view names in string literals.
</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/a2dc13847aeb685301f6be6f0f1a275c13c88074">Commit
        link</a></p>

<h2>Adding model validation with data annotations in models, checking for valid
    model state in controller, and adding validation tag helpers in view
</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Rider is better in terms of features, but the attribute completion tag is starting to annoy the hell out
    of me, thus a tie. Fix this, and Rider's going to be seriously better in this segment.</p>
<ol>
    <li>Updating <em>Create.cshtml </em>to add labels to form items and placeholders for validation messages. Good.
        Completion for tag helpers and values works well; <em>Surround with template</em> lets me group label, input and
        span in a <em>div</em>. No auto-formatting on wrap but since Rider's <em>Extend Selection</em> works in Razor
        views, I can use that and then invoke <em>Reformat Code</em> on the selection.
    </li>
    <li>Updating the <code>Restaurant</code> model and the <code>RestaurantEditModel</code> view model with data
        annotations. Hanging attribute completion strikes again in both classes! (RIDER-16880), apart from this all
        fine. Context actions to move attributes between sections are nice!<br>
        <img width="600" src="images/rider_ca_arrange_attributes.png">
    </li>
    <li>Modifying the POST-specific <code>Create()</code> action to check if the model being passed is valid. All good.
        <em>Extend Selection</em> to the entire method body, then wrapping with an if statement using <em>Surround
            With</em>. After that, either use an <em>else</em> template to return a view if model state is invalid (in
        which case the <code>else</code> block will be highlighted as redundant), or use a quick-fix on the <em>Return
            statement is missing</em> inspection to add a return:<br/>
        <img width="600" src="images/rider_qf_add_return.png">
    </li>
    <li>Adding the <code>ValidateAntiForgeryToken</code> attribute to the POST-specific
        <code>Create()</code> action: all fine.
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Visual Studio is less feature-rich but more stable. Tie again.</p>
<ol>
    <li>Updating <em>Create.cshtml </em>to add labels to form items.<em> </em>Wrapping tags with a
        <em>div</em>: <em>Shift+Alt+W</em> in Visual Studio. However the action is not reformatting the
        resulting markup, and as <em>Extend Selection</em> doesn't work in Razor, I have to select manually,
        then invoke <em>Ctrl+K,F</em> to reformat selection.
    </li>
    <li>Updating the <code>Restaurant</code> model and the <code>RestaurantEditModel</code> view model with
        data annotations, using a quick action to import <code>System.ComponentModel.DataAnnotations</code>.
    </li>
    <li>Modifying the POST-specific <code>Create()</code> action to check if the model being passed is
        valid. Scott wraps a code selection with an <code>if/else</code> manually, although there are code
        snippets in Visual Studio.
    </li>
    <li>Updating <em>Create.cshtml</em> with placeholders for possible error messages using validation tag
        helpers.
    </li>
    <li>Adding the <code>ValidateAntiForgeryToken</code> attribute to the POST-specific
        <code>Create()</code> action.
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/41e4d77d784aaed89116db1458c3c26887d49fdd">Commit
        link</a></p>

<h2>Setting up a SQL Server LocalDB connection</h2>

<h3>Observations: Rider :heart:</h3>
<ol>
    <li>Go to <em>Database &gt; Add Data source &gt; SQL Server</em>.</li>
    <li>Try to set up a connection to SQL Server Local DB, give up, drop using Rider (DBE-6705).</li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<ol>
    <li>The <em>SQL Server Object Explorer</em> view in Visual Studio shows available LocalDB instances:<br>
        <img width="600" src="images/vs_sql_server_object_explorer.png">
    </li>
    <li>Although this is quite clumsy, you can get a connection string by opening properties of an instance:<br>
        <img width="600" src="images/vs_localdb_connection_string.png">
    </li>
</ol>

<h2>Installing and configuring EF Core</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>(EF Core already installed as part of Microsoft.AspNetCore.All.)</p>
<ol>
    <li>Searching for installed packages in <em>Solution Explorer &gt; project &gt; Dependencies</em>: OK
    </li>
    <li>Installing new packages via <em>Dependencies &gt; Manage NuGet Packages</em>: OK.</li>
    <li>Editing <em>.csproj</em> to install <em>Microsoft.EntityFrameworkCore.Tools.DotNet</em> as a <code>DotNetCliToolReference</code>:
        OK. Tag name completion is better (has camelHumps support). Highlighting for empty body of an XML
        tag is annoying (funnily, it goes away on introducing a line break):<br>
        <img width="600" src="images/rider_csproj_xml_tag_has_empty_body.png">
    </li>
    <li>Executing <code>dotnet ef</code> commands: via system shell or via bundled <em>Terminal</em> window.
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>(EF Core already installed as part of Microsoft.AspNetCore.All.)</p>
<ol>
    <li>Searching for installed packages in <em>Solution Explorer &gt; project &gt; Dependencies</em>: OK
    </li>
    <li>Installing new packages via <em>Dependencies &gt; Manage NuGet Packages</em>: OK.</li>
    <li>Editing <em>.csproj</em> to install <em>Microsoft.EntityFrameworkCore.Tools.DotNet</em> as a <code>DotNetCliToolReference</code>:
        OK, although tag name completion is very basic (no camelHumps support).
    </li>
    <li>Executing <code>dotnet ef</code> commands: via system shell or via bundled <em>Package Manager
        Console</em>.
    </li>
</ol>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/6601b7d940bc70d60f3f0bbf99922d2966274779">Commit link</a></p>

<h2>Creating an EF Core <code>DbContext</code> and a service implementation
    that works with the context
</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Rider provides more automation and more convenience with its import items in completion; however, the
    Space completion behavior kind of counters the benefits.</p>
<ol>
    <li>Creating a new <em>Data</em> directory and an <code>OdeToFoodDbContext</code> class in it. Both with
        <em>Alt+Insert</em>, Git addition suggested. Good. <code>DbContext</code> is available as an import
        item in completion, imported seamlessly. <em>ctor</em>, <em>prop</em> live templates work well.
    </li>
    <li>
        Creating a new <code>SqlRestaurantData</code> service to use instead of <code>InMemoryRestaurantData</code>.
        Better because you can navigate to <code>IRestaurantData</code> and invoke a context action <em>Create derived
        type</em>, then implement missing members, then use another context action to move to a separate file, and Rider
        suggests adding it to Git. Nice.
    </li>
    <li>Implementing <code>SqlRestaurantData</code>. When adding a constructor and adding a parameter to it, you can
        <em>Alt+Enter</em> on the parameter to generate a read-only field, which is fine; but another approach would be
        to start typing an undeclared field to create from usage later, and this is where Rider's stupid space
        completion ruins the act: pressing <em>Space</em> at this point will complete the irrelevant library type
        instead of allowing me to type in a yet-to-be-declared field:<br>
        <img width="600" src="images/rider_completion_space_fail.png"><br>
        There's also a problem with <em>Complete Statement</em>
        with lambdas that I ran into (RSRP-470502) but it's unlikely to be a big deal for anyone unless they're using
        <em>Complete Statement</em> all the time.<br>Otherwise C# editing is just fine.
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Visual Studio does the job despite different commands to create items, no import completion.</p>
<ol>
    <li>Creating a new <em>Data</em> directory and an <code>OdeToFoodDbContext</code> class in it. Again,
        two different commands to create a directory and a class. Again, since there are no import items in
        completion, you have to be careful to type in <code>DbContext</code> exactly and properly cased
        before Visual Studio suggests to add an import statement with a quick action.
    </li>
    <li>Creating a new <code>SqlRestaurantData</code> service to use instead of
        <code>InMemoryRestaurantData</code>. New class is created via <em>Ctrl+Shift+A</em> as there's no
        action to create a new derived class form an existing interface.
    </li>
    <li>Implementing <code>SqlRestaurantData</code>. The <em>Implement Members</em> action generates stubs,
        then it's regular code editing inside the stubs + creating a constructor with <em>ctor</em>, and a
        field to store the context with another quick action. All good.
    </li>
</ol>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/39e74507229be3014d7d388a78663c222e204061">Commit link</a></p>

<h2>Configuring EF Core services</h2>

<h3>Observations: Rider :green_heart:</h3>
<ol>
    <li>Modifying <em>appsettings.json</em> to have a valid connection string (Rider-specific DB): OKю</li>
    <li>Modifying <em>Startup.cs</em> to update available services and get access to connection string: very much OK.
        Import completion items help; creating a constructor with <em>Alt+Ins</em>, adding a parameter + a quick-fix to
        create a field works, unless I want to start with using an undeclared field (then I'd be hit by a Space
        completion problem - see above.)
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<ol>
    <li>Modifying <em>appsettings.json</em> to have a valid connection string (Visual Studio-specific DB):
        OK.
    </li>
    <li>Modifying <em>Startup.cs</em> to update available services and get access to connection string in
        <em>appsettings.json</em>. Fine. (Importing the unimported is a bit annoying, though, again.)
    </li>
</ol>

<h3>Notes, commits</h3>
<p>Commit links:</p>
<ul>
    <li><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/16eb1abca11c39499e162f6009e7262e71c6ae52">One</a></li>
    <li><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/fd5b304e41feb597419fa3de8294adf7200b5b9f">Two</a></li>
</ul>

