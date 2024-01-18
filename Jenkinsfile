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
                    bat "dotnet test ${env.WORKSPACE}/ProductMicroservicesTest/ProductMicroserviceTest.csproj"
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
                // Add your deployment steps here
                // e.g., deploy to a server, push to a container registry, etc.
            }
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
