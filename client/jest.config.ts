import { Config } from 'jest';

const config: Config = {
  preset: 'ts-jest',
  testEnvironment: 'jsdom',
  transform: {
    '^.+\\.tsx?$': 'ts-jest',
  },
  moduleNameMapper: {
    '\\.module\\.css$': '<rootDir>/__mocks__/styleMock.js',
    '\\.css$': '<rootDir>/__mocks__/styleMock.js',
  },
  clearMocks: true,
  collectCoverage: true,
  coverageDirectory: "coverage",
  setupFilesAfterEnv: ['./src/tests/setupTests.ts'],
  coveragePathIgnorePatterns: [
    "/node_modules/",
    "/coverage",
    "package.json",
    "package-lock.json",
    "reportWebVitals.ts",
    "setupTests.ts",
    "index.tsx"
  ],
};

export default config;
