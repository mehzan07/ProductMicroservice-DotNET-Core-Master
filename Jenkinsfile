//Jenkinsfile (Declarative Pipeline)
/* Requires the Docker Pipeline plugin */
pipeline {
    agent any

    environment {
        DOTNET_SDK_VERSION = '6.0' // Update with your desired .NET Core SDK version
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                script {
                    // Install the specified .NET Core SDK version
                    def sdkInstallCommand = "dotnet-install.ps1 -Version $env:DOTNET_SDK_VERSION"
                    bat "powershell.exe -Command \"$sdkInstallCommand\""

                    // Restore project dependencies
                    bat 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                script {
                    // Build the project
                    bat 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    // Run tests
                    bat 'dotnet test --configuration Release --no-build'
                }
            }
        }

        // Add additional stages for deployment, if needed
        // stage('Deploy') {
        //     steps {
        //         // Deployment steps
        //     }
        // }
    }

    post {
        always {
            // Clean up steps, if needed
        }

        success {
            // Actions to be performed on success
        }

        failure {
            // Actions to be performed on failure
        }
    }
}

