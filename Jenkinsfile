pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = "1"
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out the code'
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                echo 'Starting Restore'
                script {
                    bat "dotnet restore ${env.WORKSPACE}/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
                }
            }
        }

        stage('Build') {
            steps {
                echo 'Starting Build'
                script {
                    bat "dotnet build ${env.WORKSPACE}/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
                }
            }
        }

        stage('Test') {
            steps {
                echo 'Starting Test'
                script {
                    bat "dotnet test ${env.WORKSPACE}/ProductMicroservicesTest/ProductMicroservicesTest.csproj"
                }
            }
        }

        stage('Publish') {
            steps {
                echo 'Starting Publish'
                script {
                    bat "dotnet publish ${env.WORKSPACE}/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj -c Release -o ${env.WORKSPACE}/publish"
                }
            }
        }

        stage('Deploy') {
    steps {
        echo 'Starting Deploy'

        // Define the target directory for deployment
        def targetDirectory = 'C:\Temp\Deployment\ProductMicroservice'

        // Create the target directory if it doesn't exist
       // bat "mkdir ${targetDirectory}"

        // Copy the published artifacts to the target directory
        bat "xcopy /s /y ${env.WORKSPACE}\\publish\\* ${targetDirectory}"

        echo 'Deployment completed'
    }
}


    post {
        success {
            echo 'Build successful - Add any additional success steps here'
        }
        failure {
            echo 'Build failed - Add any additional failure steps here'
        }
    }
}
