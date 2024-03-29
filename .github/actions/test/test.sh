#!/usr/bin/env bash
openssl aes-256-cbc -d -a -in $(pwd)/Unity_v2019.x.ulf-cipher -out /Unity_v2019.x.ulf -k ${INPUT_CYPHER}
/opt/Unity/Editor/Unity -manualLicenseFile /Unity_v2019.x.ulf -batchmode -nographics -quit

export TEST_PLATFORM=${INPUT_MODE}

set -x

echo "Testing for $TEST_PLATFORM"

${UNITY_EXECUTABLE:-xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' /opt/Unity/Editor/Unity} \
  -projectPath $(pwd) \
  -runTests \
  -testPlatform $TEST_PLATFORM \
  -testResults $(pwd)/$TEST_PLATFORM-results.xml \
  -logFile /dev/stdout \
  -batchmode

UNITY_EXIT_CODE=$?

if [ $UNITY_EXIT_CODE -eq 0 ]; then
  echo "Run succeeded, no failures occurred";
elif [ $UNITY_EXIT_CODE -eq 2 ]; then
  echo "Run succeeded, some tests failed";
elif [ $UNITY_EXIT_CODE -eq 3 ]; then
  echo "Run failure (other failure)";
else
  echo "Unexpected exit code $UNITY_EXIT_CODE";
fi

cat $(pwd)/$TEST_PLATFORM-results.xml | grep test-run | grep Passed
exit $UNITY_TEST_EXIT_CODE
