param([string]$QuestionArgs="Is this a square container?")

# Docker image name for the application
$ImageName="console-random-answer-generator"

function Invoke-Docker-Run ([string]$DockerImage, [string]$Question) {
	echo "Asking $Question"
	Invoke-Expression "docker run --rm $ImageName $Question"
}

Invoke-Docker-Run -DockerImage $ImageName -Question $QuestionArgs
