properties {
$configuration = 'Debug'
$src = resolve-path '.\src\Employee'
$sln = "src\Employee\Employee.sln"
$projects = @(gci $src -rec -filter *.csproj)

}

Task Default -depends Test

Task Test -depends Compile{
    $runners = @(gci $src\packages -rec -filter xunit.console.clr4.exe)

    if ($runners.Length -ne 1) {
        throw "Expected to find 1 xunit.console.clr4.exe, but found $($runners.Length)."
    }

    $runner = $runners[0].FullName

    foreach ($project in $projects) {
        $projectName = [System.IO.Path]::GetFileNameWithoutExtension($project)

        if ($projectName.Contains("Test")) {
            $testAssembly = "$($project.Directory)\bin\$configuration\$projectName.dll"
            exec { & $runner $testAssembly }
        }
    }
}

Task Compile {
    Exec { msbuild $sln }
    }