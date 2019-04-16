<template>
  <div class="myvaults container">
    <div class="row">
      <div v-for="vault in vaults" class="col-4">
        <div class="card pointer" @click="setActiveVault(vault)">
          <div class="card-body">
            <h4 class="card-title">{{vault.name}}</h4>
            <hr>
            <p class="card-text">{{vault.description}}
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "myvaults",
    props: [],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      setActiveVault(vault) {
        this.$store.dispatch('setActiveVault', vault)
      }
    },
    components: {}
  }
</script>