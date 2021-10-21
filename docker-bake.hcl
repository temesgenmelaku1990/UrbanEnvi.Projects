variable "REGISTRY" {
  default = "ghcr.io/urbanenvi"
}

variable "IMAGE_NAME" {
  default = "product-catalog"
}

variable "GITVERSION_SEMVER" {
  default = ""
}

variable "FEED_ACCESSTOKEN" {
  default = ""
}

variable "INCLUDE_LATEST_TAG" {
  default = true
}

function "tag" {
    params = [tag]
    result = "${REGISTRY}/${IMAGE_NAME}:${tag}"
}

target "tags" {
  tags = [
    INCLUDE_LATEST_TAG ? tag("latest") : "",
    notequal("",GITVERSION_SEMVER) ? tag(GITVERSION_SEMVER) : ""
  ]
}

target "feed-token" {
  args = {
    FEED_ACCESSTOKEN = FEED_ACCESSTOKEN
  }
}

group "default" {
  targets = ["build"]
}

target "build" {
  inherits = ["feed-token", "tags"]
  dockerfile = "src/UrbanEnvi.Projects/Dockerfile"
}